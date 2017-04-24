var filledStar = $("img[class='rating_star_hidden']").attr("src");
var emptyStar = $("img[class='rating_star']").attr("src");
$.validator.setDefaults({ ignore: [] });//не пропускать невидимые поля при валидации
$(function () {
    var rating = 0;
    $("img.rating_star").mouseover(function () {
        giveRating($(this));
        $(this).css("cursor", "pointer");
    });

    $("img.rating_star").mouseout(function () {
        if (rating > 0) giveRating($("img.rating_star").eq(rating - 1));
        else clearRating();
    });

    $("img.rating_star").click(function () {
        rating = $("img.rating_star").index($(this)) + 1;
        $("input.rating").attr("value", rating);
    });
});

function giveRating(img) {
    img.attr("src", filledStar)
       .prevAll("img.rating_star").attr("src", filledStar);
    img.nextAll("img.rating_star").attr("src", emptyStar);
}

function clearRating() {
    $("img.rating_star").attr("src", emptyStar);
}