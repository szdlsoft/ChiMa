//(function() {
//    $(function() {

//        //var _categoryService = abp.services.app.foodMaterialCategory;
//        var _categoryService = {};
//        setCategoryService = function (categoryService) {
//            _categoryService = categoryService;
//        }

//        var _$modal = $('#CategoryCreateModal');
//        var _$form = _$modal.find('form');
       

//        $('#RefreshButton').click(function () {
//            refreshUserList();
//        });

//        $('.delete-category').click(function () {
//            var categoryId = $(this).attr("data-category-id");
//            var categoryName = $(this).attr('data-category-name');

//            deleteFoodMaterialCategory(categoryId, categoryName);
//        });

//        $('.edit-category').click(function (e) {
//            var categoryId = $(this).attr("data-category-id");

//            e.preventDefault();
//            $.ajax({
//                url: abp.appPath + 'FoodMaterialCategory/EditFoodMaterialCategoryModal?categoryId=' + categoryId,
//                type: 'POST',
//                contentType: 'application/html',
//                success: function (content) {
//                    $('#categoryEditModal div.modal-content').html(content);
//                },
//                error: function (e) { }
//            });
//        });

//        _$form.find('button[type="submit"]').click(function (e) {
//            e.preventDefault();

//            if (!_$form.valid()) {
//                return;
//            }

//            var category = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            

//            abp.ui.setBusy(_$modal);
//            _categoryService.create(category).done(function () {
//                _$modal.modal('hide');
//                location.reload(true); //reload page to see new category!
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

//        function deleteFoodMaterialCategory(categoryId, categoryName) {
//            abp.message.confirm(
//                "Delete category '" + categoryName + "'?",
//                function (isConfirmed) {
//                    if (isConfirmed) {
//                        _categoryService.delete({
//                            id: categoryId
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
    ko.appService = abp.services.app.foodMaterialCategory;

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
            url: '/api/services/app/FoodMaterialCategory/GetAll',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            queryParams: function (param) {
                return { MaxResultCount: param.limit, SkipCount: param.offset };
            },//传递参数（*）
            pagination: true,                   //是否显示分页（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                      //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            onEditableSave: function (field, row, oldValue, $el) {
                var dto = row;
                ko.appService.update(dto).done(function (res) {
                    alert("编辑成功");
                    
                })
                //$.ajax({
                //    type: "post",
                //    url: "/Editable/Edit",
                //    data: { strJson: JSON.stringify(row) },
                //    success: function (data, status) {
                //        if (status == "success") {
                //            alert("编辑成功");
                //        }
                //    },
                //    error: function () {
                //        alert("Error");
                //    },
                //    complete: function () {

                //    }

                //});
            }
        });
        ko.applyBindings(this.myViewModel, document.getElementById("tb_category"));
    }
};

//操作
var operate = {
    //初始化按钮事件
    operateInit: function () {
        this.operateAdd();
        this.operateDelete();
    },
    //新增
    operateAdd: function () {
        $('#btn_add').on("click", function () {
            ko.appService.add().done(function (data) {
                tableInit.myViewModel.insertRow(data);
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
            //var oDataModel = ko.toJS(arrselectedData);
            //var _appService = abp.services.app.foodMaterial;
            abp.message.confirm(
                "Delete foodMaterialCategory '" + "'?",
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
            //取到当前的viewmodel
            var oViewModel = operate.DepartmentModel;
            //将Viewmodel转换为数据model
            var oDataModel = ko.toJS(oViewModel);
            var funcName = oDataModel.id ? "Update" : "Add";

            var _appService = abp.services.app.foodMaterial;
            if (funcName === "Add") {
                _appService.create(oDataModel).done(function (res) {
                    alert(JSON.stringify(res));
                    tableInit.myViewModel.refresh();
                });
            }
            else {
                _appService.update(oDataModel).done(function (res) {
                    alert(JSON.stringify(res));
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
