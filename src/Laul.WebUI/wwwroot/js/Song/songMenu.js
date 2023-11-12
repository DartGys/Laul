$(document).ready(function () {
    // Show/hide the dropdown menu on button click
    $('.dropdownButton').click(function (e) {
        e.stopPropagation();

        // Закрити попереднє відкрите меню
        $('.dropdown-menu').not($(this).siblings('.dropdown-menu')).hide();

        $(this).siblings('.dropdown-menu').toggle();
    });

    // Handle item selection from the dropdown
    $('.dropdown-menu').on('click', 'li', function () {
        $(this).closest('.dropdown-menu').hide();

        // Additional code for redirection
        var targetMethod = $(this).data('target');
        var controllerMethod = $(this).data('controller');
        // Redirect to the specified method
        window.location.href = '/' + controllerMethod + '/' + targetMethod;
    });

    // Close the dropdown when clicking outside of it
    $(document).click(function () {
        $('.dropdown-menu').hide();
    });
});
