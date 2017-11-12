(function() {
    $(function() {

        //var _foodMaterialService = abp.services.app.foodMaterial;
        //var _foodMaterialService = {};
        setfoodMaterialService = function (foodMaterialService) {
            _foodMaterialService = foodMaterialService;
        }

        var _$modal = $('#foodMaterialCreateModal');
        var _$form = _$modal.find('form');
       

        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-foodMaterial').click(function () {
            var foodMaterialId = $(this).attr("data-foodMaterial-id");
            var foodMaterialDescription = $(this).attr('data-foodMaterial-description');

            deleteFoodMaterial(foodMaterialId, foodMaterialDescription);
        });

        $('.edit-foodMaterial').click(function (e) {
            var foodMaterialId = $(this).attr("data-foodMaterial-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'FoodMaterial/EditFoodMaterialModal?foodMaterialId=' + foodMaterialId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#foodMaterialEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var foodMaterial = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            

            abp.ui.setBusy(_$modal);
            _foodMaterialService.create(foodMaterial).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new foodMaterial!
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

        function deleteFoodMaterial(foodMaterialId, foodMaterialDescription) {
            abp.message.confirm(
                "Delete foodMaterial '" + foodMaterialDescription + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _foodMaterialService.delete({
                            id: foodMaterialId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();