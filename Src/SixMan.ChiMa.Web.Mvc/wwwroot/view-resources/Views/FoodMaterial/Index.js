//(function() {
//    $(function() {

//        //var _foodMaterialService = abp.services.app.foodMaterial;
//        setfoodMaterialService = function (foodMaterialService) {
//            _foodMaterialService = foodMaterialService;
//        }

//        var _$modal = $('#foodMaterialCreateModal');
//        var _$form = _$modal.find('form');
       

//        $('#RefreshButton').click(function () {
//            refreshUserList();
//        });

//        $('.delete-foodMaterial').click(function () {
//            var foodMaterialId = $(this).attr("data-foodMaterial-id");
//            var foodMaterialDescription = $(this).attr('data-foodMaterial-description');

//            deleteFoodMaterial(foodMaterialId, foodMaterialDescription);
//        });

//        $('.edit-foodMaterial').click(function (e) {
//            var foodMaterialId = $(this).attr("data-foodMaterial-id");

//            e.preventDefault();
//            $.ajax({
//                url: abp.appPath + 'FoodMaterial/EditFoodMaterialModal?foodMaterialId=' + foodMaterialId,
//                type: 'POST',
//                contentType: 'application/html',
//                success: function (content) {
//                    $('#foodMaterialEditModal div.modal-content').html(content);
//                },
//                error: function (e) { }
//            });
//        });

//        _$form.find('button[type="submit"]').click(function (e) {
//            e.preventDefault();

//            if (!_$form.valid()) {
//                return;
//            }

//            var foodMaterial = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            

//            abp.ui.setBusy(_$modal);
//            _foodMaterialService.create(foodMaterial).done(function () {
//                _$modal.modal('hide');
//                location.reload(true); //reload page to see new foodMaterial!
//            }).always(function () {
//                abp.ui.clearBusy(_$modal);
//            });
//        });
        
//        _$modal.on('shown.bs.modal', function () {
//            _$modal.find('input:not([type=hidden]):first').focus();
//        });

//        function refreshUserList() {
//            location.reload(true); //reload page to see new category!
//        }

//        function deleteFoodMaterial(foodMaterialId, foodMaterialDescription) {
//            abp.message.confirm(
//                "Delete foodMaterial '" + foodMaterialDescription + "'?",
//                function (isConfirmed) {
//                    if (isConfirmed) {
//                        _foodMaterialService.delete({
//                            id: foodMaterialId
//                        }).done(function () {
//                            refreshUserList();
//                        });
//                    }
//                }
//            );
//        }
//    });
//})();

//初始化
$(function () {
    //0, 设置service
    var _foodMaterialService = abp.services.app.foodMaterial;

    //1、初始化表格
    tableInit.Init();

    //2、注册增删改事件
    operate.operateInit();
});

//初始化表格
var tableInit = {
    Init: function () {
        //绑定table的viewmodel
        this.myViewModel = new ko.bootstrapTableViewModel({
            url: '/api/services/app/FoodMaterial/GetFoodMaterials',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            queryParams: function (param) {
                return { limit: param.limit, offset: param.offset };
            },//传递参数（*）
            pagination: true,                   //是否显示分页（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                      //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
        });
        ko.applyBindings(this.myViewModel, document.getElementById("tb_dept"));
    }
};

//操作
var operate = {
    //初始化按钮事件
    operateInit: function () {
        this.operateAdd();
        this.operateUpdate();
        this.operateDelete();
        this.DepartmentModel = {
            id: ko.observable(),
            description: ko.observable(),
            season: ko.observable()
        };
    },
    //新增
    operateAdd: function () {
        $('#btn_add').on("click", function () {
            $("#myModal").modal().on("shown.bs.modal", function () {
                var oEmptyModel = {
                    id: ko.observable(),
                    description: ko.observable(),
                    season: ko.observable()
                };
                ko.utils.extend(operate.DepartmentModel, oEmptyModel);
                ko.applyBindings(operate.DepartmentModel, document.getElementById("myModal"));
                operate.operateSave();
            }).on('hidden.bs.modal', function () {
                ko.cleanNode(document.getElementById("myModal"));
            });
        });
    },
    //编辑
    operateUpdate: function () {
        $('#btn_edit').on("click", function () {
            $("#myModal").modal().on("shown.bs.modal", function () {
                var arrselectedData = tableInit.myViewModel.getSelections();
                if (!operate.operateCheck(arrselectedData)) { return; }
                //将选中该行数据有数据Model通过Mapping组件转换为viewmodel
                ko.utils.extend(operate.DepartmentModel, ko.mapping.fromJS(arrselectedData[0]));
                ko.applyBindings(operate.DepartmentModel, document.getElementById("myModal"));
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
            var _appService = abp.services.app.foodMaterial;
            abp.message.confirm(
            "Delete foodMaterial '"  + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _appService.deleteList({
                            ids: idsData
                        }
                        ).done(function () {
                            tableInit.myViewModel.refresh();
                        });
                    }
                }
            );
            // $.ajax({
            //     url: "/FoodMaterial/Delete",
            //     type: "post",
            //     contentType: 'application/json',
            //     data: JSON.stringify(arrselectedData),
            //     success: function (data, status) {
            //         //alert(status);
            //         tableInit.myViewModel.refresh();
            //     }
            // });
        });
    },
    //保存数据
    operateSave: function () {
        $('#btn_submit').on("click", function () {
            //取到当前的viewmodel
            var oViewModel = operate.DepartmentModel;
            //将Viewmodel转换为数据model
            var oDataModel = ko.toJS(oViewModel);
            var funcName = oDataModel.id ? "Update" : "Add";

            var _appService = abp.services.app.foodMaterial;
            if( funcName === "Add"){
                _appService.create(oDataModel).done(function (res) {
                    alert(JSON.stringify(res) );
                    tableInit.myViewModel.refresh();
                });                
            }
            else{
                _appService.update(oDataModel).done(function (res) {
                    alert(JSON.stringify(res) );
                    tableInit.myViewModel.refresh();
                });            
            }

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