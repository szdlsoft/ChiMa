//添加ko自定义绑定
ko.bindingHandlers.myBootstrapTable = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        //这里的oParam就是绑定的viewmodel
        var oViewModel = valueAccessor();
        var $ele = $(element).bootstrapTable(oViewModel.params);
        //给viewmodel添加bootstrapTable方法
        oViewModel.bootstrapTable = function () {
            return $ele.bootstrapTable.apply($ele, arguments);
        }
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {}
};

//初始化
(function ($) {
    //向ko里面新增一个bootstrapTableViewModel方法
    ko.bootstrapTableViewModel = function (options) {
        var that = this;

        this.default = {
            search: true,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            cache:false,
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            showToggle: true,
            totalField: 'totalCount',
            dataField: 'items',
            queryParams: function (param) {
                return {
                    MaxResultCount: param.limit
                    , SkipCount: param.offset
                    , Search: param.search
                    , Sort: param.sort
                    , Order: param.order
                };
            },//传递参数（*）
            pagination: true, 
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                      //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）

            responseHandler:  function (res) {
                if (res.result) {
                    return res.result;
                }
                return res;
            }
        };
        this.params = $.extend({}, this.default, options || {});

        //得到选中的记录
        this.getSelections = function () {
            var arrRes = that.bootstrapTable("getSelections")
            return arrRes;
        };

        //刷新
        this.refresh = function () {
            that.bootstrapTable("refresh");
        };
        //新增
        this.insertRow = function (data) {
            that.bootstrapTable("insertRow", {
                index: 0,
                row:   data
            });
        };
    };
})(jQuery);

var domainCrud = domainCrud || {};
function crudInit(options) {
    //初始化配置
    domainCrud.urlPath = options.urlPath;
    domainCrud.appService = options.appService;
    domainCrud.onBeforeKoCleanNode = options.onBeforeKoCleanNode || function () { };
    domainCrud.onAfterKoCleanNode = options.onAfterKoCleanNode || function () { };

    domainCrud.importModal = options.importModal || "importModal";
    domainCrud.tbList = options.tbList || "tb_list";
    domainCrud.myModal = options.myModal || "myModal"; //暂时不用
    domainCrud.myForm = options.myForm || "myForm";//暂时不用

    //1、初始化表格
    tableInit.Init();
    //2、注册增删改事件
    operate.operateInit();
    //3、设置表格的列宽度可拖动调整列宽
    setAutoColDragAdjust();
}

function uploadImg() {
    var formData = new FormData();
    formData.append('id',  operate.EntityModel.id());
    formData.append('imgfile', $("#imgfile")[0].files[0]);
    $.ajax({
        type: "POST",
        url: '/' + domainCrud.urlPath + '/UploadImg',
        contentType: false,
        processData: false,
        data: formData,
        success: function (res) {
            if (res.success) {
                operate.EntityModel.photo(res.result);
                abp.notify.success('上传文件成功：', res.result);
            }
            else {
                abp.message.error('上传文件出现错误:', res.error.message);
            }
        },
        error: function () {
            alert("上传文件出现错误！");
        }
    });
}

function ImportViewModel() {
    var self = this;

    self.importRunning = ko.observable(false);
    self.importComplete = ko.observable(false);
    self.importPercent = ko.observable('20%');
    self.importCancel = ko.observable(false);
    self.workId = ko.observable('');

    self.exeUpload = function () {
        var formData = new FormData($("#uploadForm")[0]);
        //$.ajax({
        //    type: "POST",
        //    url: '/' + domainCrud.urlPath + '/Import',
        //    contentType: false,
        //    processData: false,
        //    data: formData,
        //    success: function (res) {
        //        if (res.success) {
        //            abp.notify.success('上传文件成功', '导入任务：' + res.result.taskId);
        //            self.update(res.result);
        //        }
        //        else {
        //            abp.notify.error('上传文件失败：', res.error.message);
        //        }
        //    },
        //    error: function (res) {

        //        alert("上传文件出现错误:" + res);
        //    }
        //});

        abp.ajax({
            url: '/' + domainCrud.urlPath + '/Import',
            contentType: false,
            processData: false,
            data: formData,
        }).done(function (data) {
            abp.notify.success('上传文件成功', '导入任务：' + data.taskId);
            self.update(data);
        });


        self.startTimer();
    }

    self.startTimer = function () {
        if (!self.timer) {
            self.timer = setInterval(self.query, 3000);
        }
    }

    self.stopTimer = function () {
        if (self.timer) {
            clearTimeout(self.timer);
            self.timer = null;
        }
    }

    self.query = function () {
        domainCrud.appService.queryWork({
            taskId: self.workId
        }).done(self.update);
    };
    self.cancel = function () {
        //停止定时器
        clearTimeout(self.timer);
        domainCrud.appService.cancelWork({
            taskId: self.workId
        }).done(self.update);          
    }

    self.update = function (res) {
        self.importRunning(res.isRunning);
        self.importComplete(res.complete);
        self.importPercent(res.percent.toString()+'%');
        self.workId(res.taskId);
        //启动定时器;
       
        //self.startTimer();
    } 
}

//初始化表格
var tableInit = {
    Init: function () {
        //绑定table的viewmodel
        this.myViewModel = new ko.bootstrapTableViewModel({
            url: '/api/services/app/' + domainCrud.urlPath + '/GetAll',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
        });
        ko.applyBindings(this.myViewModel, document.getElementById(domainCrud.tbList));
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
        this.EntityModel = new EntityModel();
    },
    //导入
    operateUpload: function () {
        $('#btn_upload').on("click", function () {
            $("#importModal").modal().on("shown.bs.modal", function () {
                
            }).on('hidden.bs.modal', function () {
               
            });
        });
        var importVM = new ImportViewModel();
        importVM.query();
        ko.applyBindings(importVM, document.getElementById(domainCrud.importModal));
    },
    //上传图像
    //operateUploadImg: function () {
    //    $('#btn_upload_img').on("click", function () {
    //        var formData = new FormData();
    //        //formData.append('photo', $("#photo")[0].value);
    //        formData.append('photo', operate.EntityModel.id());
    //        formData.append('imgfile', $("#imgfile")[0].files[0]);
    //        $.ajax({
    //            type: "POST",
    //            url: '/' + domainCrud.urlPath + '/UploadImg',
    //            contentType: false,
    //            processData: false,
    //            data: formData,
    //            success: function (res) {
    //                if (res.success) {
    //                    operate.EntityModel.photo(res.result);
    //                }
    //                else {
    //                    abp.message.error('上传文件出现错误:', res.error.message);
    //                }
    //            },
    //            error: function () {
    //                alert("上传文件出现错误！");
    //            }
    //        });
    //    });
    //},
    //新增
    operateAdd: function () {
        $('#btn_add').on("click", function () {
            $("#myModal").modal().on("shown.bs.modal", function () {
                var oEmptyModel = new EntityModel();
                ko.utils.extend(operate.EntityModel, oEmptyModel);
                ko.applyBindings(operate.EntityModel, document.getElementById(domainCrud.myModal));
                operate.operateSave();
            }).on('hidden.bs.modal', function () {
                domainCrud.onBeforeKoCleanNode();
                ko.cleanNode(document.getElementById(domainCrud.myModal));
                domainCrud.onAfterKoCleanNode();
            });
        });
    },
    //编辑
    operateUpdate: function () {
        $('#btn_edit').on("click", function () {
            var arrselectedData = tableInit.myViewModel.getSelections();
            if (!operate.operateCheck(arrselectedData)) { return; }
            $("#myModal").modal({
                backdrop: 'static'
            }).on("shown.bs.modal", function () {
                //将选中该行数据有数据Model通过Mapping组件转换为viewmodel
                ko.utils.extend(operate.EntityModel, ko.mapping.fromJS(arrselectedData[0]));
                ko.applyBindings(operate.EntityModel, document.getElementById(domainCrud.myModal));
                operate.operateSave();
            }).on('hidden.bs.modal', function () {
                //关闭弹出框的时候清除绑定(这个清空包括清空绑定和清空注册事件)
                domainCrud.onBeforeKoCleanNode();
                ko.cleanNode(document.getElementById(domainCrud.myModal));
                domainCrud.onAfterKoCleanNode();
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
                        domainCrud.appService.deleteList({
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
                domainCrud.appService.create(oDataModel).done(function (res) {
                    alert(JSON.stringify(res));
                    tableInit.myViewModel.refresh();
                });
            }
            else {
                domainCrud.appService.update(oDataModel).done(function (res) {
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
