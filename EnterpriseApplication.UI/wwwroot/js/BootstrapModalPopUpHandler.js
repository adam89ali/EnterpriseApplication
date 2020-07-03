function ModalPopUpHandler() {
     //will be fired on clicking add, edit and delete popup button...
    this.SetUpModalWhileShowingPopup = function (placeHolderForModelId, placeHolderForButtonsId)
    {
        var placeHolderForButtons = $('#' + placeHolderForButtonsId);
        var placeHolderForModel = $('#' + placeHolderForModelId);
       // placeHolderForButtons.off("click");
        placeHolderForButtons.on("click", 'button[data-toggle="ajax-Modal"]', function () {

            var url = $(this).data('url');
            var decodedUrl = decodeURIComponent(url);
            $.get(decodedUrl).done(function (data) {
                placeHolderForModel.html(data);
                placeHolderForModel.find('.modal').modal('show');
            });
        });
    }

        //will be fired on add, edit and delete...
    this.SetUpModalWhileClosingPopup = function (placeHolderId,callback)
    {
        var placeHolder = $('#' + placeHolderId);
       // placeHolder.off("click");
        placeHolder.on("click", '[data-save="modal"]', function (event) {
                var form = $(this).parents('.modal').find('form');
                var actionUrl = form.attr('action');
                var dataTobeSend = form.serialize();
                $.post(actionUrl, dataTobeSend).done(function (data) {
                    callback();
                    placeHolder.find('.modal').modal('hide');
                    //console.log(data);
                    toastr.success(data);
                }).fail(function (error) {
                    placeHolder.find('.modal').modal('hide');
                    var message = "";
                    error.responseJSON.forEach(function (item,index) { message += item.errorMessage + "<br/>";  });
                    toastr.error(message);
                });
            });
    }
       



}