function onDeleteFromBasket(id) {
    if (onDeleteFromBasket.deleteEntry == true)
    {
        $("#" + id + ".goodsListItem").remove();
    }
    else
    {
        $("#" + id + ".DeleteFromBasketButton").hide();
        $("#" + id + ".AddToBasketButton").show();
    }
}

function onAddToBasket(id) {
    $("#" + id + ".AddToBasketButton").hide();
    $("#" + id + ".DeleteFromBasketButton").show();
}