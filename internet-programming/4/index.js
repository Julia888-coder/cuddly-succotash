const form = document.querySelector('#processForm');

form.addEventListener('submit', (e) => {
    // отключение стандартного сценария события
    e.preventDefault();

    // получение данных с помозью FormData
    const formData = new FormData(form);
    // Получение полей, здесь меняйте на свои поля.
    // Но не забывайте менять также атрибут name у полей формы
    const dataPhone = formData.get('tel');
    const dataPass = formData.get('password');

    const isValid = dataPhone.startsWith('+7') && dataPass.length > 6

    if (!isValid) {
        return Swal.fire(
            'Ошибка',
            'Проверьте данные',
            'error'
        );
    }
    return Swal.fire(
        'Успешно',
        'Данные успешно прошли проверку',
        'success'
    );
});