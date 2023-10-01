import { SUBJECT_STYLING } from "../app.enum";

export const convertDateTimeToVn = function (datetime) {
    //Buoc 1: Lay 10 ki tu dau cua datetime 
    const dt = datetime.slice(0, 10);

    //Buoc 2: Dinh dang theo kieu thoi gian cua Viet Nam
    //2.1 : Tach rieng ngay, thang, nam thanh 3 phan tu cua 1 mang
    const dtArr = dt.split("-"); //["2006", "10", "06"]
    //2.2 :  Dao nguoc nam va ngay ["06", "10", "2006"]
    const temp = dtArr[0];
    dtArr[0] = dtArr[2];
    dtArr[2] = temp;
    //2.3 : Ghep 3 phan tu vao va phan tach boi dau gach cheo
    return dtArr.join("/");

}

export const trimMillisecondsFromTime = function (time) {
    return time.slice(0, 5);
}

export const convertDateTimeToISO = function (datetime) {
    //2008-09-21T00:00:00	
    const dtISOArr = datetime.split("/");
    const temp = dtISOArr[0];
    dtISOArr[0] = dtISOArr[2];
    dtISOArr[2] = temp;
    return dtISOArr.join("-") + "T00:00:00";
}

export const getFirstDayOfMonth = function (year, month) {
    return new Date(year, month, 1).getDay();
}

export const getLastDayOfMonth = function (year, month) {
    return new Date(year, month + 1, 0).getDay();
}

export const getLastDateOfMonth = function (year, month) {
    return new Date(year, month + 1, 0).getDate();
}

export const calculateTimetableGridRow = function (from = new Date()) {
    const initialTime = new Date(from);
    initialTime.setHours(7, 0, 0);
    const minutesPassed = Math.round((from - initialTime) / 1000 / 60);
    const gridRow = minutesPassed / 5 + 2;
    return gridRow;
}

export const calculateTimetableColStart = function (from = new Date()) {
    const weekday = from.getDay();
    if (weekday === 0) return 7;
    return weekday;
}

export const formatTime = function (d = new Date()) {
    return d.toLocaleTimeString([], { hour: 'numeric', minute: '2-digit', hour12: true });
}

export const displayTimetables = function (timetablesOl, timetables) {
    timetablesOl.innerHTML = "";
    timetables.forEach(t => {
        const from = new Date(t.from);
        const to = new Date(t.to);
        const subjectId = t.teacher.subject.id;
        const styling = SUBJECT_STYLING[subjectId];
        const gridRow = calculateTimetableGridRow(from);
        const colStart = calculateTimetableColStart(from);
        const colStartClassName = `col-start-${colStart}`;
        if (timetablesOl.classList.contains("sm:grid-cols-7")) {
            timetablesOl.insertAdjacentHTML("beforeend", `
            <li class="relative mt-px flex ${colStartClassName}" style="grid-row: ${gridRow} / span 12">
                <a href="#"
                    class="group absolute inset-1 flex flex-col overflow-y-auto rounded-lg ${styling.bg} p-2 text-xs leading-5 ${styling.hoverBg}">
                    <p class="order-1 font-semibold ${styling.text700}">${t.teacher.subject.name}</p>
                    <p class="order-1 ${styling.text600} ${styling.groupHoverText700} italic">Topic: ${t.topic}</p>
                    <p class="${styling.text500} ${styling.groupHoverText700}"><time
                            datetime="${t.from}">${formatTime(from)} - ${formatTime(to)}</time></p>
                </a>
            </li>
            `);
        } else {
            timetablesOl.insertAdjacentHTML("beforeend", `
            <li class="relative mt-px flex" style="grid-row: ${gridRow} / span 12">
                <a href="#"
                    class="group absolute inset-1 flex flex-col overflow-y-auto rounded-lg ${styling.bg} p-2 text-xs leading-5 ${styling.hoverBg}">
                    <p class="order-1 font-semibold ${styling.text700}">${t.teacher.subject.name}</p>
                    <p class="order-1 ${styling.text600} ${styling.groupHoverText700} italic">Topic: ${t.topic}</p>
                    <p class="${styling.text500} ${styling.groupHoverText700}">
                        <time datetime="${t.from}">${formatTime(from)} - ${formatTime(to)}</time>
                    </p>
                </a>
            </li>
            `);
        }

    });
}