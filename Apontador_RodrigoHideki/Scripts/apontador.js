$(function () {
    $.ajaxSetup({ cache: false });
    $("a[data-modal]").on("click", function (e) {
        $('#apontadorModalContent').load(this.href, function () {
            $('#apontadorModal').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $('#progress').show();
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#apontadorModal').modal('hide');
                    $('#progress').hide();
                    location.reload();
                } else {
                    $('#progress').hide();
                    $('#apontadorModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}
