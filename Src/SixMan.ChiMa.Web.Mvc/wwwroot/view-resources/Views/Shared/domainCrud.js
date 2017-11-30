var urlDomain = '';
function crudInit(domain) {
    urlDomain = domain;
    //1、初始化表格
    tableInit.Init();
    //2、注册增删改事件
    operate.operateInit();
    //3、设置表格的列宽度可拖动调整列宽
    setAutoColDragAdjust();
}

function uploadImg() {
    var formData = new FormData();
    formData.append('photo', $("#photo")[0].value);
    formData.append('imgfile', $("#imgfile")[0].files[0]);
    $.ajax({
        type: "POST",
        url: '/' + urlDomain + '/UploadImg',
        contentType: false,
        processData: false,
        data: formData,
        success: function (message) {
            alert(message);
        },
        error: function () {
            alert("上传文件出现错误！");
        }
    });
}

//初始化表格
var tableInit = {
    Init: function () {
        //绑定table的viewmodel
        this.myViewModel = new ko.bootstrapTableViewModel({
            url: '/api/services/app/' + urlDomain + '/GetAll',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
        });
        ko.applyBindings(this.myViewModel, document.getElementById("tb_list"));
    }
};

//操作
var operate = {
    //初始化按钮事件
    operateInit: function (domain) {
        this.operateUpload();
        //this.operateUploadImg();

        this.operateAdd();
        this.operateUpdate();
        this.operateDelete();
        this.EntityModel = newEntityModel();
    },
    //导入
    operateUpload: function () {
        $('#btn_upload').on("click", function () {
            var formData = new FormData($("#uploadForm")[0]);
            $.ajax({
                type: "POST",
                url: '/' + urlDomain + '/Import',
                contentType: false,
                processData: false,
                data: formData,
                success: function (message) {
                    alert(message);
                    tableInit.myViewModel.refresh();
                },
                error: function () {
                    alert("上传文件出现错误！");
                }
            });
        });
    },
    //上传图像
    operateUploadImg: function () {
        $('#btn_upload_img').on("click", function () {
            var formData = new FormData();
            formData.append('photo', $("#photo")[0].value);
            formData.append('imgfile', $("#imgfile")[0].files[0]);
            $.ajax({
                type: "POST",
                url: '/' + urlDomain + '/UploadImg',
                contentType: false,
                processData: false,
                data: formData,
                success: function (message) {
                    alert(message);
                },
                error: function () {
                    alert("上传文件出现错误！");
                }
            });
        });
    },
    //新增
    operateAdd: function () {
        $('#btn_add').on("click", function () {
            $("#myModal").modal().on("shown.bs.modal", function () {
                var oEmptyModel = newEntityModel();
                ko.utils.extend(operate.EntityModel, oEmptyModel);
                ko.applyBindings(operate.EntityModel, document.getElementById("myModal"));
                operate.operateSave();
            }).on('hidden.bs.modal', function () {
                ko.cleanNode(document.getElementById("myModal"));
            });
        });
    },
    //编辑
    operateUpdate: function () {
        $('#btn_edit').on("click", function () {
            var arrselectedData = tableInit.myViewModel.getSelections();
            if (!operate.operateCheck(arrselectedData)) { return; }
            $("#myModal").modal().on("shown.bs.modal", function () {
                //将选中该行数据有数据Model通过Mapping组件转换为viewmodel
                ko.utils.extend(operate.EntityModel, ko.mapping.fromJS(arrselectedData[0]));
                ko.applyBindings(operate.EntityModel, document.getElementById("myModal"));
                operate.operateSave();
            }).on('hidden.bs.modal', function () {
                //关闭弹出框的时候清除绑定(这个清空包括清空绑定和清空注册事件)
                ko.cleanNode(document.getElementById("myModal"));
            });
        });
    },
    //删除
    operateDelete: function () {
        $('#btn_delete').on("click", function () {
            var arrselectedData = tableInit.myViewModel.getSelections();
            //var data = JSON.stringify(arrselectedData);
            var idsData = arrselectedData.map(function (item) {
                return item.id;
            }).join(",");
            var oDataModel = ko.toJS(arrselectedData);
            abp.message.confirm(
                "Delete foodMaterial '" + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        ko.appService.deleteList({
                            ids: idsData
                        }
                        ).done(function () {
                            tableInit.myViewModel.refresh();
                        });
                    }
                }
            );
        });
    },
    //保存数据
    operateSave: function () {
        $('#btn_submit').on("click", function () {
            var form = $("#myForm");
            $.validator.unobtrusive.parse(form);
            if (!form.valid()) {
                event.preventDefault();
                return;
            }
            //取到当前的viewmodel
            var oViewModel = operate.EntityModel;
            //将Viewmodel转换为数据model
            var oDataModel = ko.toJS(oViewModel);
            var funcName = oDataModel.id ? "Update" : "Add";

            if (funcName === "Add") {
                ko.appService.create(oDataModel).done(function (res) {
                    alert(JSON.stringify(res));
                    tableInit.myViewModel.refresh();
                });
            }
            else {
                ko.appService.update(oDataModel).done(function (res) {
                    alert(JSON.stringify(res));
                    tableInit.myViewModel.refresh();
                });
            }
            $("#myModal").modal("hide");

        });
    },
    //数据校验
    operateCheck: function (arr) {
        if (arr.length <= 0) {
            alert("请至少选择一行数据");
            return false;
        }
        if (arr.length > 1) {
            alert("只能编辑一行数据");
            return false;
        }
        return true;
    }
}
