$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);
        $.ajax({
            url: `/Games/Delete/${btn.data('id')}`,
            method: 'DELETE',

            success: function () {
                alert('Dame deleted successfully');
            },

            error: function () {
                alert('Error deleting Dame');
            }
        })
    });
});