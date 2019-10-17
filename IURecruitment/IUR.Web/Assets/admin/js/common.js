jQuery(document).ready(function ($) {
    'use strict';
    // ==============================================================
    // Alert Box
    // ==============================================================
    //$("#toast-container").removeClass('hide');
    //$("#toast-container").delay(5000).slideUp(500);

    toastr.options.timeOut = 1500;    
    toastr.options.progressBar = true;
    toastr.options.preventDuplicates = true;
    toastr.options.hideMethod = 'slideUp';
    toastr.options.closeMethod = 'slideUp';


    $('#chkAll').off('click').on('click', function () {
        var isChecked = $(this).prop('checked');
        $('.chkDelete').prop('checked', isChecked);
    });
});