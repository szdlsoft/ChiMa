(function ($) {
    console.log("begin");
    var _appService = abp.services.app.foodMaterial;
    var _$modal = $('#foodMaterialEditModal');
    var _$form = $('form[name=foodMaterialEditForm]');

    function save() {

        if (!_$form.valid()) {
            console.log('form notvalid!');
            return;
        }

        var FoodMaterial = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        console.log('FoodMaterial:' + FoodMaterial);
        //alert("forml ok!");
        abp.ui.setBusy(_$form);
        _appService.update(FoodMaterial).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited FoodMaterial!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        //alert("save botton click!");
        console.log("save botton click!");
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);