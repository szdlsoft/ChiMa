(function() {
    $(function() {

        var _categoryService = abp.services.app.foodMaterialCategory;
        var _$modal = $('#CategoryCreateModal');
        var _$form = _$modal.find('form');
       

        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-category').click(function () {
            var categoryId = $(this).attr("data-category-id");
            var categoryName = $(this).attr('data-category-name');

            deleteFoodMaterialCategory(categoryId, categoryName);
        });

        $('.edit-category').click(function (e) {
            var categoryId = $(this).attr("data-category-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'FoodMaterialCategory/EditFoodMaterialCategoryModal?categoryId=' + categoryId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#categoryEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var category = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            

            abp.ui.setBusy(_$modal);
            _categoryService.create(category).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new category!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshUserList() {
            location.reload(true); //reload page to see new category!
        }

        function deleteFoodMaterialCategory(categoryId, categoryName) {
            abp.message.confirm(
                "Delete category '" + categoryName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _categoryService.delete({
                            id: categoryId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();