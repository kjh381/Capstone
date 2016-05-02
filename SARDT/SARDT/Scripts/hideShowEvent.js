//Hide or show events

$('.event').click(function () {
    if ($(this).hasClass('current'))
    {
        $(this).children('.description').hide();
        $('.event').removeClass('current');
    }
    else
    {
        $('.event').removeClass('current');
        $('.description').hide();

        $(this).addClass('current');
        $(this).children('.description').show();
    }   
});
