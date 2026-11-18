$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });

    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });

    $('.search-box input').on('focus', function () {
        $(this).select();
    });

    $(document).on('click', '.theloai-link', function (e) {
        e.preventDefault();
        var $link = $(this);

        $.get($link.data('url'), function (html) {
            $('#main-content').html(html);
            $('.menu li').removeClass('active');
            $link.closest('li').addClass('active');
        }).fail(function () {
            alert('Không tải được dữ liệu');
        });
    });
});
