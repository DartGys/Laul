$(document).ready(function () {
    // Приклад Ajax-запиту
    $.ajax({
        url: '/YourController/YourAction', // URL вашого методу на сервері
        type: 'GET', // або 'POST', залежно від вашого випадку
        success: function (data) {
            // Відображення модального вікна при успішній відповіді
            $('#myModal').modal('show');
            // Змініть вміст модального вікна відповідно до отриманих даних
            $('.modal-body').html(data);
        },
        error: function (error) {
            // Логіка обробки помилки
            console.error(error);
        }
    });
});