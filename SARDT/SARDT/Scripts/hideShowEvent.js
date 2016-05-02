//Hide or show events

$('.event').click(function () {
    $('.event').removeClass('current');
    $('.description').hide();

    $(this).addClass('current');
    $(this).children('.description').show();
});