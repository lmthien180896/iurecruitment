var controlConfig = {
    pageSize: 10,
    pageIndex: 1
};

var footerController = {
    init: function () {      
        footerController.registerEvent();
    },

    registerEvent: function () {
        $('#btnSubmit').off('click').on('click', function () {
            var id = $('#txtID').val();
            txtContent.updateElement();
            var content = $('#txtContent').val();
            var data = {
                ID: id,
                Content: content
            };
            $.ajax({
                url: '/Admin/Common/SaveFooter',
                data: { model: JSON.stringify(data) },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        window.location.reload();
                    }
                    else {
                        toastr.error(response.message);
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    }
};

footerController.init();