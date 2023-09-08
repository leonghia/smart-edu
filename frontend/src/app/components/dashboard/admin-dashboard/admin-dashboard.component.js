import dataService from "../../../services/data.service";
import { formatDatetime } from "../../../helpers/datetime.helper.js";
import { searchByName } from "../../../helpers/search.helper.js";

export class AdminDashboardComponent extends HTMLElement {
    #students;

    constructor() {
        super();
    }

    connectedCallback() {
        // document.documentElement = <html></html>
        document.documentElement.classList.remove("bg-white");
        document.documentElement.classList.add("bg-gray-900");
        this.innerHTML = this.#renderDashboard();
        const main = document.querySelector("main");
        main.insertAdjacentHTML("beforeend", this.#renderStudentsMenu());
        this.#renderStudentRows();
    }

    disconnectedCallback() {

    }

    #renderDashboard() {
        return `
        <div class="h-full">
            <div class="relative z-50 xl:hidden" role="dialog" aria-modal="true">
                <div class="fixed inset-0 bg-gray-900/80"></div>
                <div class="fixed inset-0 flex">
                    <div class="relative mr-16 flex w-full max-w-xs flex-1">
                        <div class="absolute left-full top-0 flex w-16 justify-center pt-5">
                            <button type="button" class="-m-2.5 p-2.5">
                                <span class="sr-only">Close sidebar</span>
                                <svg class="h-6 w-6 text-white" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                    stroke="currentColor" aria-hidden="true">
                                    <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
                                </svg>
                            </button>
                        </div>

                        <div class="flex grow flex-col gap-y-5 overflow-y-auto bg-gray-900 px-6 ring-1 ring-white/10">
                            <div class="flex h-16 shrink-0 items-center">
                                <img class="h-8 w-auto"
                                    src="https://tailwindui.com/img/logos/mark.svg?color=fuchsia&shade=500"
                                    alt="Your Company">
                            </div>
                            <nav class="flex flex-1 flex-col">
                                <ul role="list" class="flex flex-1 flex-col gap-y-7">
                                    <li>
                                        <div class="text-xs font-semibold leading-6 text-gray-400">Menu</div>
                                        <ul role="list" class="-mx-2 mt-2 space-y-1">
                                            <li>

                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <svg class="h-6 w-6 shrink-0" fill="none" viewBox="0 0 24 24"
                                                        stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                                                        <path stroke-linecap="round" stroke-linejoin="round"
                                                            d="M2.25 12.75V12A2.25 2.25 0 014.5 9.75h15A2.25 2.25 0 0121.75 12v.75m-8.69-6.44l-2.12-2.12a1.5 1.5 0 00-1.061-.44H4.5A2.25 2.25 0 002.25 6v12a2.25 2.25 0 002.25 2.25h15A2.25 2.25 0 0021.75 18V9a2.25 2.25 0 00-2.25-2.25h-5.379a1.5 1.5 0 01-1.06-.44z" />
                                                    </svg>
                                                    Dashboard
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#"
                                                    class="bg-fuchsia-500 text-white group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M18 18.72a9.094 9.094 0 003.741-.479 3 3 0 00-4.682-2.72m.94 3.198l.001.031c0 .225-.012.447-.037.666A11.944 11.944 0 0112 21c-2.17 0-4.207-.576-5.963-1.584A6.062 6.062 0 016 18.719m12 0a5.971 5.971 0 00-.941-3.197m0 0A5.995 5.995 0 0012 12.75a5.995 5.995 0 00-5.058 2.772m0 0a3 3 0 00-4.681 2.72 8.986 8.986 0 003.74.477m.94-3.197a5.971 5.971 0 00-.94 3.197M15 6.75a3 3 0 11-6 0 3 3 0 016 0zm6 3a2.25 2.25 0 11-4.5 0 2.25 2.25 0 014.5 0zm-13.5 0a2.25 2.25 0 11-4.5 0 2.25 2.25 0 014.5 0z" />
                                                    </svg>
                                                    Students
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M15 19.128a9.38 9.38 0 002.625.372 9.337 9.337 0 004.121-.952 4.125 4.125 0 00-7.533-2.493M15 19.128v-.003c0-1.113-.285-2.16-.786-3.07M15 19.128v.106A12.318 12.318 0 018.624 21c-2.331 0-4.512-.645-6.374-1.766l-.001-.109a6.375 6.375 0 0111.964-3.07M12 6.375a3.375 3.375 0 11-6.75 0 3.375 3.375 0 016.75 0zm8.25 2.25a2.625 2.625 0 11-5.25 0 2.625 2.625 0 015.25 0z" />
                                                    </svg>
                                                    Parents
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M4.26 10.147a60.436 60.436 0 00-.491 6.347A48.627 48.627 0 0112 20.904a48.627 48.627 0 018.232-4.41 60.46 60.46 0 00-.491-6.347m-15.482 0a50.57 50.57 0 00-2.658-.813A59.905 59.905 0 0112 3.493a59.902 59.902 0 0110.399 5.84c-.896.248-1.783.52-2.658.814m-15.482 0A50.697 50.697 0 0112 13.489a50.702 50.702 0 017.74-3.342M6.75 15a.75.75 0 100-1.5.75.75 0 000 1.5zm0 0v-3.675A55.378 55.378 0 0112 8.443m-7.007 11.55A5.981 5.981 0 006.75 15.75v-1.5" />
                                                    </svg>
                                                    Teachers
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <svg class="h-6 w-6 shrink-0" fill="none" viewBox="0 0 24 24"
                                                        stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                                                        <path stroke-linecap="round" stroke-linejoin="round"
                                                            d="M7.5 14.25v2.25m3-4.5v4.5m3-6.75v6.75m3-9v9M6 20.25h12A2.25 2.25 0 0020.25 18V6A2.25 2.25 0 0018 3.75H6A2.25 2.25 0 003.75 6v12A2.25 2.25 0 006 20.25z" />
                                                    </svg>
                                                    Main Classes
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="h-6 w-6 shrink-0">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M6.75 7.5l3 2.25-3 2.25m4.5 0h3m-9 8.25h13.5A2.25 2.25 0 0021 18V6a2.25 2.25 0 00-2.25-2.25H5.25A2.25 2.25 0 003 6v12a2.25 2.25 0 002.25 2.25z" />
                                                    </svg>
                                                    Extra Classes
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <div class="text-xs font-semibold leading-6 text-gray-400">Your teams</div>
                                        <ul role="list" class="-mx-2 mt-2 space-y-1">
                                            <li>

                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <span
                                                        class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">Q</span>
                                                    <span class="truncate">Trinh Dinh Quoc</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <span
                                                        class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">H</span>
                                                    <span class="truncate">Nguyen Thi Huong</span>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#"
                                                    class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                                    <span
                                                        class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">P</span>
                                                    <span class="truncate">Trinh Van Phuc</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li class="-mx-6 mt-auto mb-2">
                                        <div
                                            class="flex items-center justify-between px-6 py-3 text-sm font-semibold leading-6 text-white">
                                            <div class="flex items-center gap-x-4">
                                                <img class="h-8 w-8 rounded-full bg-gray-800"
                                                src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                                                alt="">
                                                <span class="sr-only">Your profile</span>
                                                <span aria-hidden="true">Hi, Quoc 👋</span>
                                            </div>
                                            <div class="flex items-center gap-x-3">
                                                <span class="text-gray-400 hover:text-fuchsia-400 cursor-pointer">
                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="#d946ef" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M21.752 15.002A9.718 9.718 0 0118 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 003 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 009.002-5.998z" />
                                                    </svg>                                              
                                                </span>
                                                <span class="text-gray-400 hover:text-fuchsia-400 cursor-pointer">
                                                    <svg class="h-6 w-6 shrink-0" fill="none" viewBox="0 0 24 24"
                                                    stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                                                        <path stroke-linecap="round" stroke-linejoin="round"
                                                            d="M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.324.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 011.37.49l1.296 2.247a1.125 1.125 0 01-.26 1.431l-1.003.827c-.293.24-.438.613-.431.992a6.759 6.759 0 010 .255c-.007.378.138.75.43.99l1.005.828c.424.35.534.954.26 1.43l-1.298 2.247a1.125 1.125 0 01-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.57 6.57 0 01-.22.128c-.331.183-.581.495-.644.869l-.213 1.28c-.09.543-.56.941-1.11.941h-2.594c-.55 0-1.02-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 01-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 01-1.369-.49l-1.297-2.247a1.125 1.125 0 01.26-1.431l1.004-.827c.292-.24.437-.613.43-.992a6.932 6.932 0 010-.255c.007-.378-.138-.75-.43-.99l-1.004-.828a1.125 1.125 0 01-.26-1.43l1.297-2.247a1.125 1.125 0 011.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.087.22-.128.332-.183.582-.495.644-.869l.214-1.281z" />
                                                        <path stroke-linecap="round" stroke-linejoin="round"
                                                            d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                                    </svg>
                                                </span>
                                            </div>                                      
                                        </div>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>


            <div class="hidden xl:fixed xl:inset-y-0 xl:z-50 xl:flex xl:w-72 xl:flex-col">

                <div class="flex grow flex-col gap-y-5 overflow-y-auto bg-black/10 px-6 ring-1 ring-white/5">
                    <div class="flex h-16 shrink-0 items-center">
                        <img class="h-8 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=fuchsia&shade=500"
                            alt="Your Company">
                    </div>
                    <nav class="flex flex-1 flex-col">
                        <ul role="list" class="flex flex-1 flex-col gap-y-7">
                            <li>
                                <div class="text-xs font-semibold leading-6 text-gray-400">Menu</div>
                                <ul role="list" class="-mx-2 mt-1 space-y-1">
                                    <li>

                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <svg class="h-6 w-6 shrink-0" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                                stroke="currentColor" aria-hidden="true">
                                                <path stroke-linecap="round" stroke-linejoin="round"
                                                    d="M2.25 12.75V12A2.25 2.25 0 014.5 9.75h15A2.25 2.25 0 0121.75 12v.75m-8.69-6.44l-2.12-2.12a1.5 1.5 0 00-1.061-.44H4.5A2.25 2.25 0 002.25 6v12a2.25 2.25 0 002.25 2.25h15A2.25 2.25 0 0021.75 18V9a2.25 2.25 0 00-2.25-2.25h-5.379a1.5 1.5 0 01-1.06-.44z" />
                                            </svg>
                                            Dashboard
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"
                                            class="bg-fuchsia-500 text-white group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M18 18.72a9.094 9.094 0 003.741-.479 3 3 0 00-4.682-2.72m.94 3.198l.001.031c0 .225-.012.447-.037.666A11.944 11.944 0 0112 21c-2.17 0-4.207-.576-5.963-1.584A6.062 6.062 0 016 18.719m12 0a5.971 5.971 0 00-.941-3.197m0 0A5.995 5.995 0 0012 12.75a5.995 5.995 0 00-5.058 2.772m0 0a3 3 0 00-4.681 2.72 8.986 8.986 0 003.74.477m.94-3.197a5.971 5.971 0 00-.94 3.197M15 6.75a3 3 0 11-6 0 3 3 0 016 0zm6 3a2.25 2.25 0 11-4.5 0 2.25 2.25 0 014.5 0zm-13.5 0a2.25 2.25 0 11-4.5 0 2.25 2.25 0 014.5 0z" />
                                            </svg>
                                            Students
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 19.128a9.38 9.38 0 002.625.372 9.337 9.337 0 004.121-.952 4.125 4.125 0 00-7.533-2.493M15 19.128v-.003c0-1.113-.285-2.16-.786-3.07M15 19.128v.106A12.318 12.318 0 018.624 21c-2.331 0-4.512-.645-6.374-1.766l-.001-.109a6.375 6.375 0 0111.964-3.07M12 6.375a3.375 3.375 0 11-6.75 0 3.375 3.375 0 016.75 0zm8.25 2.25a2.625 2.625 0 11-5.25 0 2.625 2.625 0 015.25 0z" />
                                            </svg>
                                            Parents
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M4.26 10.147a60.436 60.436 0 00-.491 6.347A48.627 48.627 0 0112 20.904a48.627 48.627 0 018.232-4.41 60.46 60.46 0 00-.491-6.347m-15.482 0a50.57 50.57 0 00-2.658-.813A59.905 59.905 0 0112 3.493a59.902 59.902 0 0110.399 5.84c-.896.248-1.783.52-2.658.814m-15.482 0A50.697 50.697 0 0112 13.489a50.702 50.702 0 017.74-3.342M6.75 15a.75.75 0 100-1.5.75.75 0 000 1.5zm0 0v-3.675A55.378 55.378 0 0112 8.443m-7.007 11.55A5.981 5.981 0 006.75 15.75v-1.5" />
                                            </svg>
                                            Teachers
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <svg class="h-6 w-6 shrink-0" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                                stroke="currentColor" aria-hidden="true">
                                                <path stroke-linecap="round" stroke-linejoin="round"
                                                    d="M7.5 14.25v2.25m3-4.5v4.5m3-6.75v6.75m3-9v9M6 20.25h12A2.25 2.25 0 0020.25 18V6A2.25 2.25 0 0018 3.75H6A2.25 2.25 0 003.75 6v12A2.25 2.25 0 006 20.25z" />
                                            </svg>
                                            Main Classes
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="h-6 w-6 shrink-0">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M6.75 7.5l3 2.25-3 2.25m4.5 0h3m-9 8.25h13.5A2.25 2.25 0 0021 18V6a2.25 2.25 0 00-2.25-2.25H5.25A2.25 2.25 0 003 6v12a2.25 2.25 0 002.25 2.25z" />
                                            </svg>
                                            Extra Classes
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <div class="text-xs font-semibold leading-6 text-gray-400">Your teams</div>
                                <ul role="list" class="-mx-2 mt-2 space-y-1">
                                    <li>

                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <span
                                                class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">Q</span>
                                            <span class="truncate">Trinh Dinh Quoc</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <span
                                                class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">H</span>
                                            <span class="truncate">Nguyen Thi Huong</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"
                                            class="text-gray-400 hover:text-white hover:bg-fuchsia-500 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                            <span
                                                class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">P</span>
                                            <span class="truncate">Trinh Van Phuc</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li class="-mx-6 mt-auto mb-2">
                                <div
                                    class="flex items-center justify-between px-6 py-3 text-sm font-semibold leading-6 text-white">
                                    <div class="flex items-center gap-x-4">
                                        <img class="h-8 w-8 rounded-full bg-gray-800"
                                        src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                                        alt="">
                                        <span class="sr-only">Your profile</span>
                                        <span aria-hidden="true">Hi, Quoc 👋</span>
                                    </div>
                                    <div class="flex items-center gap-x-3">
                                        <span class="text-gray-400 hover:text-fuchsia-400 cursor-pointer">
                                            <svg xmlns="http://www.w3.org/2000/svg" fill="#d946ef" viewBox="0 0 24 24" stroke-width="0" stroke="currentColor" class="w-6 h-6 shrink-0">
                                            <path stroke-linecap="round" stroke-linejoin="round" d="M21.752 15.002A9.718 9.718 0 0118 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 003 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 009.002-5.998z" />
                                            </svg>                                      
                                        </span>
                                        <span class="text-gray-400 hover:text-fuchsia-400 cursor-pointer">
                                            <svg class="h-6 w-6 shrink-0" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                            stroke="currentColor" aria-hidden="true">
                                                <path stroke-linecap="round" stroke-linejoin="round"
                                                    d="M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.324.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 011.37.49l1.296 2.247a1.125 1.125 0 01-.26 1.431l-1.003.827c-.293.24-.438.613-.431.992a6.759 6.759 0 010 .255c-.007.378.138.75.43.99l1.005.828c.424.35.534.954.26 1.43l-1.298 2.247a1.125 1.125 0 01-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.57 6.57 0 01-.22.128c-.331.183-.581.495-.644.869l-.213 1.28c-.09.543-.56.941-1.11.941h-2.594c-.55 0-1.02-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 01-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 01-1.369-.49l-1.297-2.247a1.125 1.125 0 01.26-1.431l1.004-.827c.292-.24.437-.613.43-.992a6.932 6.932 0 010-.255c.007-.378-.138-.75-.43-.99l-1.004-.828a1.125 1.125 0 01-.26-1.43l1.297-2.247a1.125 1.125 0 011.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.087.22-.128.332-.183.582-.495.644-.869l.214-1.281z" />
                                                <path stroke-linecap="round" stroke-linejoin="round"
                                                    d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                            </svg>
                                        </span>
                                    </div>                                
                                </div>
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>

            <div class="xl:pl-72 se-right-container h-full">

                <div
                    class="rounded-tr-lg sticky top-0 z-40 flex h-16 shrink-0 items-center gap-x-6 border-b border-white/5 bg-gray-900 px-4 shadow-sm sm:px-6 lg:px-8">
                    <button type="button" class="-m-2.5 p-2.5 text-white xl:hidden">
                        <span class="sr-only">Open sidebar</span>
                        <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path fill-rule="evenodd"
                                d="M2 4.75A.75.75 0 012.75 4h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 4.75zM2 10a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 10zm0 5.25a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75a.75.75 0 01-.75-.75z"
                                clip-rule="evenodd" />
                        </svg>
                    </button>

                    <div class="flex flex-1 gap-x-4 self-stretch lg:gap-x-6">
                        <form class="flex flex-1">
                            <label for="search-field" class="sr-only">Search</label>
                            <div class="relative w-full">
                                <svg class="pointer-events-none absolute inset-y-0 left-0 h-full w-5 text-gray-500"
                                    viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                    <path fill-rule="evenodd"
                                        d="M9 3.5a5.5 5.5 0 100 11 5.5 5.5 0 000-11zM2 9a7 7 0 1112.452 4.391l3.328 3.329a.75.75 0 11-1.06 1.06l-3.329-3.328A7 7 0 012 9z"
                                        clip-rule="evenodd" />
                                </svg>
                                <input id="search-field"
                                    class="block h-full w-full border-0 bg-transparent py-0 pl-8 pr-0 text-white focus:ring-0 focus:outline-none sm:text-sm"
                                    placeholder="Search..." type="search" name="search">
                            </div>
                        </form>
                    </div>
                </div>
                <main class="" style="height: calc(100% - 4rem);"> 
                </main>
            </div>
        </div>
        `;
    }

    #toggleTab() {

    }

    #renderStudentsMenu() {
        return `
        <div class="h-full">
            <div class="mx-auto max-w-full h-full">
                <div class="py-10 h-full">
                    <div class="px-4 sm:px-6 lg:px-8 h-full">
                        <div class="sm:flex sm:items-center h-16">
                            <div class="sm:flex-auto">
                            <h1 class="text-base font-semibold leading-6 text-white">Students</h1>
                            <p class="mt-2 text-sm text-gray-300">A list of all the students in your application including their identifiers, names, dates of birth, emails, classes and parents.</p>
                            </div>
                            <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
                            <button type="button" class="block rounded-md bg-fuchsia-500 px-3 py-2 text-center text-sm font-semibold text-white hover:bg-fuchsia-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-fuchsia-500">Add Student</button>
                            </div>
                        </div>
                        <div class="mt-8 flow-root h-full" style="height: calc(100% - 4rem);">
                            <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8 h-full">
                                <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8 h-full">
                                    <table class="min-w-full divide-y divide-gray-700">
                                    <thead>
                                        <tr>
                                        <th scope="col" class="py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-white">No.</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white sm:pl-0">Full Name</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Student ID</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Status</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Class</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Date Of Birth</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Email</th>
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Parent</th>
                                        <th scope="col" class="relative py-3.5 pl-3 pr-4 sm:pr-0">
                                            <span class="sr-only">Edit</span>
                                        </th>
                                        <th scope="col" class="relative py-3.5 pl-3 pr-4 sm:pr-0">
                                            <span class="sr-only">Delete</span>
                                        </th>
                                        </tr>
                                    </thead>
                                    <tbody class="divide-y divide-gray-800">
                                        
                                    </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>  
        `;
    }

    #renderStudentRows() {
        Promise.resolve(new Array())
            .then(data => {
                for (let i = 0; i < 100; i++) {
                    data.push(i);
                }
                //Buoc1: Xac dinh phan tu: thanh tim kiem
                const form = document.querySelector("form");
                const searchField = document.querySelector("#search-field");
                const tableBody = document.querySelector("tbody");

                //Buoc 2: Gan su kien nhan Enter vao form
                form.addEventListener("submit", function (event) {
                    event.preventDefault();


                    //Buoc 3: Hien thi ket qua tim kiem

                    const results = searchByName(data, searchField.value);
                    console.log(data);
                    console.log(searchField.value);

                    //Buoc 3.1: Xoa bang hien tai 
                    tableBody.innerHTML = "";
                    //Buoc 3.2: 
                    let resultMarkup;
                    results.forEach(currentValue => {
                        resultMarkup = `
                    <tr>
                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-white sm:pl-0"><span class="hover:text-fuchsia-500 cursor-pointer">${"Trinh Dinh Quoc"}</span></td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">${formatDatetime("2004-03-26T00:00:00")}</td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">${"no1hoatieu@gmail.com"}</td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-300">Student</td>
                        <td class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                            <a href="#" class="text-emerald-400 hover:text-emerald-300">Edit<span class="sr-only">, ${"Trinh Dinh Quoc"}</span></a>
                        </td>
                        <td class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                            <a href="#" class="text-rose-400 hover:text-rose-300">Delete<span class="sr-only">, ${"Trinh Dinh Quoc"}</span></a>
                        </td>
                    </tr>
                    `;
                        tableBody.insertAdjacentHTML("beforeend", resultMarkup);
                    })

                });

                let markup;
                data.forEach((currentValue, currentIndex) => {
                    markup = `
                    <tr>
                        <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm text-gray-300">${currentIndex + 1}</td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm font-medium text-white sm:pl-0">
                            <div class="flex items-center gap-x-4">
                            <img src="https://nghia.b-cdn.net/smart-edu/images/users/default-pfp.webp" alt="${"Trinh Dinh Quoc"}" class="h-8 w-8 rounded-full bg-gray-800">
                            <div class="truncate text-sm font-medium leading-6 text-white hover:text-fuchsia-400 cursor-pointer">${"Trinh Dinh Quoc"}</div>
                            </div>
                        </td>
                        <td class="whitespace-nowrap px-3 py-4 font-mono text-sm leading-6 text-gray-400">${"STU04.002589"}</td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm leading-6">
                            <div class="flex items-center justify-end gap-x-2 sm:justify-start">
                                <div class="flex-none rounded-full p-1 ${true ? "text-green-400 bg-green-400/10" : "text-gray-500 bg-gray-100/10"}">
                                    <div class="h-1.5 w-1.5 rounded-full bg-current"></div>
                                </div>
                                <div class="hidden text-white sm:block">${true ? "Online" : "Offline"}</div>
                            </div>
                        </td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-400">${"10A"}</td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-400">${formatDatetime("2004-03-26T00:00:00")}</td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-400">${"no1hoatieu@gmail.com"}</td>
                        <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-400"><span class="hover:text-fuchsia-400 cursor-pointer"> ${"La Trong Nghia"}</span></td>
                        <td class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                            <a href="#" class="text-emerald-400 hover:text-emerald-300">Edit<span class="sr-only">, ${"Trinh Dinh Quoc"}</span></a>
                        </td>
                        <td class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                            <a href="#" class="text-rose-400 hover:text-rose-300">Delete<span class="sr-only">, ${"Trinh Dinh Quoc"}</span></a>
                        </td>
                    </tr>
                    `;
                    tableBody.insertAdjacentHTML("beforeend", markup);
                })
            });
    }
}

customElements.define("admin-dashboard", AdminDashboardComponent);
