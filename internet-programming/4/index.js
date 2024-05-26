const form = document.querySelector('#processForm');

form.addEventListener('submit', (e) => {
    e.preventDefault();

    const formData = new FormData(form);
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