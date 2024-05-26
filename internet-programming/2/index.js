const form = document.getElementById('processForm');

function fetchGet(uri, param) {
    // encode URI необходим для преобразования символов. В кабинетах необходим для преобразования слеша 
    const uriResult = uri + encodeURIComponent(param);
    return fetch(uriResult).then((data) => data.json())
}

// Получение расписания для группы
async function getScheduleByGroup(groupName) {
    return fetchGet('https://vm.nathoro.ru/timetable/by-group/', groupName);
}

// Получение расписания для учителя
async function getScheduleByTeacher(teacherName) {
    return fetchGet('https://vm.nathoro.ru/timetable/by-teacher/', teacherName);
}

// Получение расписания для кабинета
async function getScheduleByRoom(roomName) {
    return fetchGet('https://vm.nathoro.ru/timetable/by-room/', roomName);
}

function clearWeeks() {
    //Очистка таблицы с помощью айди
    document.querySelectorAll('#app > *').forEach(d => d.remove())
}

// Получение тектового описания
function getLessonText(lesson) {
    const { room, group, subject } = lesson;
    return `${subject.type} ${subject.name} ${room.name} ${group.name} ${subject.teacher.fullName}`
}

form.addEventListener('submit', (e) => {
    //Отключаем перезагрузку страницы при нажатии
    e.preventDefault();
    const formData = new FormData(form);
    // данные поля из формы
    const data = formData.get('data');
    getScheduleByGroup(data)
        .then((data) => {
            clearWeeks()
            for (const w of data) {
                renderWeek(w);
            }
        })
});
form.addEventListener('reset', (e) => {
    e.preventDefault();
    
    clearWeeks();
    Swal.fire(
        'Успешный результат',
        'Данные очищены',
        'success'
    );
});

function renderWeek(week) {
    // Добавление заголовка
    const isOddText = week.isOdd ? 'чётная' : 'нечётная'; 
    const title = document.createElement('h3');
    title.innerText = `Неделя – ${isOddText}`

    const weekDiv = document.createElement('div');
    weekDiv.append(title)

    const table = document.createElement('table');
    for (const day of week.days) {
        renderDay(day, table);
    }
    weekDiv.append(table);
    document.getElementById('app').append(weekDiv);
}

function renderDay(day, table) {
    const row = document.createElement('tr');
    for (const lesson of day.lessons) {
        renderLesson(lesson, row);
    }
    table.append(row);
}

function renderLesson(lesson, row) {
    const cell = document.createElement('td');
    if (lesson) {
        const { room, group, subject } = lesson;
        cell.innerHTML = getLessonText(lesson)
        cell.style = 'background-color: greenyellow';
    } else {
        cell.innerHTML = '/----/';
        cell.style = 'background-color: red';
    }
    row.append(cell);
}