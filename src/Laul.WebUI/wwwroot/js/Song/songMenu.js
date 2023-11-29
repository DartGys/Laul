$(document).ready(function () {
    // Show/hide the dropdown menu on button click
    $('.dropdownButton').click(function (e) {
        e.stopPropagation();

        // Закрити попереднє відкрите меню
        $('.dropdown-menu').not($(this).siblings('.dropdown-menu')).hide();

        $(this).siblings('.dropdown-menu').toggle();
    });
    $(document).click(function () {
        $('.dropdown-menu').hide();
    });
});
