function checkEmptyLists() {
    $("[data-empty-message]").html(
    function (index, value) {
        if (value.trim() == "") {
            return '<div class="emptyMessage">' + $(this).data("emptyMessage") + '</div>';
        }
        else
        {
            return value;
        }
    });
};
$(function () { checkEmptyLists(); });
$(document).ajaxComplete(checkEmptyLists);