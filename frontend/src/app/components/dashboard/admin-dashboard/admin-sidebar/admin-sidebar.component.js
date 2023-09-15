import { showDropdown, hideDropdown } from "../../../../helpers/animation.helper.js";
import authService from "../../../../services/auth.service.js";
import { state } from "../../../../app.store.js";

export class AdminSidebarComponent extends HTMLElement {

    #settingDropdown;
    #settingBtn;
    #settingItems;
    #settingState = {
        state: false
    }
    #logoutBtn;
    #sidebarMenuContainer;
    #darkModeBtn;

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#settingDropdown = document.querySelector("#se_setting_dropdown");
        this.#settingBtn = document.querySelector("#se_setting_btn");
        this.#settingItems = document.querySelectorAll(".se-setting-item");
        const settingItemsArr = Array.from(this.#settingItems);
        this.#logoutBtn = document.querySelector("#setting-item-2");
        this.#sidebarMenuContainer = document.querySelector(".se-sidebar-menu-container");
        this.#darkModeBtn = document.querySelector("#se_dark_mode_btn");

        this.#darkModeBtn.addEventListener("click", function() {
            state.darkMode = !state.darkMode; //false => true va true => false
            if (state.darkMode) {
                this.#enableDarkMode();
            } else {
                this.#disableDarkMode();
            }
        }.bind(this));

        this.#sidebarMenuContainer.addEventListener("click", function(event) {
            const clicked = event.target.closest("a");
            if (!clicked) {
                return;
            }
            const items = this.#sidebarMenuContainer.querySelectorAll("a");
            items.forEach(a => {
                if (state.darkMode) {
                    a.classList.remove("dark:bg-gray-800", "dark:text-white");
                    a.classList.add("dark:text-gray-400", "dark:hover:text-white", "dark:hover:bg-gray-800");
                } else {
                    a.classList.remove("bg-gray-200", "text-gray-700");
                    a.classList.add("text-gray-600", "hover:text-gray-700", "hover:bg-gray-200");
                }
            });

            if (state.darkMode) {
                clicked.classList.remove("dark:text-gray-400", "dark:hover:text-white", "dark:hover:bg-gray-800");
                clicked.classList.add("dark:bg-gray-800", "dark:text-white");
            } else {
                clicked.classList.remove("text-gray-600", "hover:text-gray-700", "hover:bg-gray-200");
                clicked.classList.add("bg-gray-200", "text-gray-700");
            }
            
        }.bind(this));

        // this.#sidebarMenuContainer.addEventListener("mouseover", function(event) {
        //     const clicked = event.target.closest("a");
        //     if (!clicked) {
        //         return;
        //     }
        //     clicked.firstElementChild.classList.remove("text-gray-900", "text-opacity-40", "dark:text-gray-400");
        //     clicked.firstElementChild.classList.add("text-white");
        // }.bind(this));

        // this.#sidebarMenuContainer.addEventListener("mouseout", function(event) {
        //     const clicked = event.target.closest("a");
        //     if (!clicked) {
        //         return;
        //     }
        //     clicked.firstElementChild.classList.remove("text-white");
        //     clicked.firstElementChild.classList.add("text-gray-900", "text-opacity-40", "dark:text-gray-400");
        // }.bind(this));

        this.#settingBtn.addEventListener("click", function() {
            if (this.#settingState.state) {
                hideDropdown(this.#settingDropdown, settingItemsArr, this.#settingState);
                this.#unHighlightSettingBtn();
                return;
            }
            this.#highlightSettingBtn();
            showDropdown(this.#settingDropdown, settingItemsArr, this.#settingState);
        }.bind(this));

        this.#settingDropdown.addEventListener("click", function(event) {
            const clicked = event.target.closest(".se-setting-item");
            if (!clicked) {
                return;
            }
            hideDropdown(this.#settingDropdown, settingItemsArr, this.#settingState);
            this.#unHighlightSettingBtn();
        }.bind(this));

        this.#logoutBtn.addEventListener("click",function(){
            authService.logout();
        });

    }

    disconnectedCallback() {

    }

    // Bat che do nen toi
    #enableDarkMode() {
        // B1: Them class "dark" vao the <html>
        document.documentElement.classList.add("dark");
        this.#darkModeBtn.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6">
        <path fill-rule="evenodd" d="M9.528 1.718a.75.75 0 01.162.819A8.97 8.97 0 009 6a9 9 0 009 9 8.97 8.97 0 003.463-.69.75.75 0 01.981.98 10.503 10.503 0 01-9.694 6.46c-5.799 0-10.5-4.701-10.5-10.5 0-4.368 2.667-8.112 6.46-9.694a.75.75 0 01.818.162z" clip-rule="evenodd" />
      </svg>
      
        `;

        // B2: Cap nhat "darkmode" trong app.store.js thanh true
    } 

    // Tat che do nen toi
    #disableDarkMode() {
        // B1: Xoa class "dark" khoi <html>
        document.documentElement.classList.remove("dark");
        this.#darkModeBtn.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
  <path stroke-linecap="round" stroke-linejoin="round" d="M21.752 15.002A9.718 9.718 0 0118 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 003 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 009.002-5.998z" />
</svg>
        `;
    }

    #render() {
        return `

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
                                                    class="text-gray-400 hover:text-white hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
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
                                                    <svg xmlns="http://www.w3.org/2000/svg" fill="#d946ef" viewBox="0 0 24 24" stroke-width="0" stroke="currentColor" class="w-6 h-6 shrink-0">
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

        <div class="hidden xl:fixed xl:inset-y-0 xl:z-50 xl:flex xl:w-72 xl:flex-col se-sidebar">
            <div id="se_sidebar" class="flex grow flex-col gap-y-5 bg-black/10 px-6 ring-1 ring-white/5">
                <div class="flex h-16 shrink-0 items-center">
                    <img class="h-8 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=fuchsia&shade=500"
                        alt="Your Company">
                </div>
                <nav class="flex flex-1 flex-col">
                    <ul role="list" class="flex flex-1 flex-col gap-y-7">
                        <li>
                            <div class="text-xs font-semibold leading-6 text-gray-900 dark:text-gray-400">Menu</div>
                            <ul role="list" class="-mx-2 mt-1 space-y-1 se-sidebar-menu-container">
                                <li>

                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">                              
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="text-amber-600 w-6 h-6 shrink-0">
                                            <path d="M11.47 3.84a.75.75 0 011.06 0l8.69 8.69a.75.75 0 101.06-1.06l-8.689-8.69a2.25 2.25 0 00-3.182 0l-8.69 8.69a.75.75 0 001.061 1.06l8.69-8.69z" />
                                            <path d="M12 5.432l8.159 8.159c.03.03.06.058.091.086v6.198c0 1.035-.84 1.875-1.875 1.875H15a.75.75 0 01-.75-.75v-4.5a.75.75 0 00-.75-.75h-3a.75.75 0 00-.75.75V21a.75.75 0 01-.75.75H5.625a1.875 1.875 0 01-1.875-1.875v-6.198a2.29 2.29 0 00.091-.086L12 5.43z" />
                                        </svg>
                                        Dashboard
                                    </a>
                                </li>
                                <li>
                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="text-blue-600 w-6 h-6 shrink-0">
                                            <path fill-rule="evenodd" d="M18.685 19.097A9.723 9.723 0 0021.75 12c0-5.385-4.365-9.75-9.75-9.75S2.25 6.615 2.25 12a9.723 9.723 0 003.065 7.097A9.716 9.716 0 0012 21.75a9.716 9.716 0 006.685-2.653zm-12.54-1.285A7.486 7.486 0 0112 15a7.486 7.486 0 015.855 2.812A8.224 8.224 0 0112 20.25a8.224 8.224 0 01-5.855-2.438zM15.75 9a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0z" clip-rule="evenodd" />
                                        </svg>
                                        Students
                                    </a>
                                </li>
                                <li>
                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="text-pink-500 w-6 h-6 shrink-0">
                                            <path d="M4.5 6.375a4.125 4.125 0 118.25 0 4.125 4.125 0 01-8.25 0zM14.25 8.625a3.375 3.375 0 116.75 0 3.375 3.375 0 01-6.75 0zM1.5 19.125a7.125 7.125 0 0114.25 0v.003l-.001.119a.75.75 0 01-.363.63 13.067 13.067 0 01-6.761 1.873c-2.472 0-4.786-.684-6.76-1.873a.75.75 0 01-.364-.63l-.001-.122zM17.25 19.128l-.001.144a2.25 2.25 0 01-.233.96 10.088 10.088 0 005.06-1.01.75.75 0 00.42-.643 4.875 4.875 0 00-6.957-4.611 8.586 8.586 0 011.71 5.157v.003z" />
                                        </svg>
                                        Parents
                                    </a>
                                </li>
                                <li>
                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="text-cyan-600 w-6 h-6 shrink-0">
                                            <path d="M11.7 2.805a.75.75 0 01.6 0A60.65 60.65 0 0122.83 8.72a.75.75 0 01-.231 1.337 49.949 49.949 0 00-9.902 3.912l-.003.002-.34.18a.75.75 0 01-.707 0A50.009 50.009 0 007.5 12.174v-.224c0-.131.067-.248.172-.311a54.614 54.614 0 014.653-2.52.75.75 0 00-.65-1.352 56.129 56.129 0 00-4.78 2.589 1.858 1.858 0 00-.859 1.228 49.803 49.803 0 00-4.634-1.527.75.75 0 01-.231-1.337A60.653 60.653 0 0111.7 2.805z" />
                                            <path d="M13.06 15.473a48.45 48.45 0 017.666-3.282c.134 1.414.22 2.843.255 4.285a.75.75 0 01-.46.71 47.878 47.878 0 00-8.105 4.342.75.75 0 01-.832 0 47.877 47.877 0 00-8.104-4.342.75.75 0 01-.461-.71c.035-1.442.121-2.87.255-4.286A48.4 48.4 0 016 13.18v1.27a1.5 1.5 0 00-.14 2.508c-.09.38-.222.753-.397 1.11.452.213.901.434 1.346.661a6.729 6.729 0 00.551-1.608 1.5 1.5 0 00.14-2.67v-.645a48.549 48.549 0 013.44 1.668 2.25 2.25 0 002.12 0z" />
                                            <path d="M4.462 19.462c.42-.419.753-.89 1-1.394.453.213.902.434 1.347.661a6.743 6.743 0 01-1.286 1.794.75.75 0 11-1.06-1.06z" />
                                        </svg>
                                        Teachers
                                    </a>
                                </li>
                                <li>
                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="text-violet-600 w-6 h-6 shrink-0">
                                            <path fill-rule="evenodd" d="M3 6a3 3 0 013-3h12a3 3 0 013 3v12a3 3 0 01-3 3H6a3 3 0 01-3-3V6zm4.5 7.5a.75.75 0 01.75.75v2.25a.75.75 0 01-1.5 0v-2.25a.75.75 0 01.75-.75zm3.75-1.5a.75.75 0 00-1.5 0v4.5a.75.75 0 001.5 0V12zm2.25-3a.75.75 0 01.75.75v6.75a.75.75 0 01-1.5 0V9.75A.75.75 0 0113.5 9zm3.75-1.5a.75.75 0 00-1.5 0v9a.75.75 0 001.5 0v-9z" clip-rule="evenodd" />
                                        </svg>
                                        Main Classes
                                    </a>
                                </li>
                                <li>
                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="text-green-600 w-6 h-6 shrink-0">
                                            <path fill-rule="evenodd" d="M3 6a3 3 0 013-3h12a3 3 0 013 3v12a3 3 0 01-3 3H6a3 3 0 01-3-3V6zm14.25 6a.75.75 0 01-.22.53l-2.25 2.25a.75.75 0 11-1.06-1.06L15.44 12l-1.72-1.72a.75.75 0 111.06-1.06l2.25 2.25c.141.14.22.331.22.53zm-10.28-.53a.75.75 0 000 1.06l2.25 2.25a.75.75 0 101.06-1.06L8.56 12l1.72-1.72a.75.75 0 10-1.06-1.06l-2.25 2.25z" clip-rule="evenodd" />
                                        </svg>
                                        Extra Classes
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <div class="text-xs font-semibold leading-6 text-gray-900 dark:text-gray-400">Your teams</div>
                            <ul role="list" class="-mx-2 mt-2 space-y-1">
                                <li>

                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <span
                                            class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">Q</span>
                                        <span class="truncate">Trinh Dinh Quoc</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <span
                                            class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">H</span>
                                        <span class="truncate">Nguyen Thi Huong</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#"
                                        class="text-gray-600 dark:text-gray-400 hover:text-gray-700 dark:hover:text-white hover:bg-gray-200 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold">
                                        <span
                                            class="flex h-6 w-6 shrink-0 items-center justify-center rounded-lg border border-gray-700 bg-gray-800 text-[0.625rem] font-medium text-gray-400 group-hover:text-white">P</span>
                                        <span class="truncate">Trinh Van Phuc</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="-mx-6 mt-auto mb-2">
                            <div
                                class="flex items-center justify-between px-6 py-3 text-sm font-semibold leading-6 text-gray-800 dark:text-white">
                                <div class="flex items-center gap-x-4">
                                    <img class="h-8 w-8 rounded-full bg-gray-800"
                                    src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                                    alt="">
                                    <span class="sr-only">Your profile</span>
                                    <span aria-hidden="true">Hi, Quoc 👋</span>
                                </div>
                                <div class="flex items-center gap-x-3">
                                    <div>
                                        <span id="se_dark_mode_btn" class="text-gray-700 dark:text-gray-400 cursor-pointer">
                                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                <path stroke-linecap="round" stroke-linejoin="round" d="M21.752 15.002A9.718 9.718 0 0118 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 003 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 009.002-5.998z" />
                                            </svg>                                      
                                        </span>
                                    </div>
                                    <div class="relative inline-block text-left">
                                        <div>
                                            <span id="se_setting_btn" class="text-gray-700 dark:text-gray-400 cursor-pointer">
                                                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.324.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 011.37.49l1.296 2.247a1.125 1.125 0 01-.26 1.431l-1.003.827c-.293.24-.438.613-.431.992a6.759 6.759 0 010 .255c-.007.378.138.75.43.99l1.005.828c.424.35.534.954.26 1.43l-1.298 2.247a1.125 1.125 0 01-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.57 6.57 0 01-.22.128c-.331.183-.581.495-.644.869l-.213 1.28c-.09.543-.56.941-1.11.941h-2.594c-.55 0-1.02-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 01-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 01-1.369-.49l-1.297-2.247a1.125 1.125 0 01.26-1.431l1.004-.827c.292-.24.437-.613.43-.992a6.932 6.932 0 010-.255c.007-.378-.138-.75-.43-.99l-1.004-.828a1.125 1.125 0 01-.26-1.43l1.297-2.247a1.125 1.125 0 011.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.087.22-.128.332-.183.582-.495.644-.869l.214-1.281z" />
                                                    <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                                </svg>
                                                                                    
                                            </span>                                    
                                        </div>
                                        <div id="se_setting_dropdown"
                                        class="bottom-10 transform opacity-0 scale-95 transition ease-out duration-700 absolute z-10 w-52 origin-top-right rounded-md bg-gray-800 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                                        role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                                            <div class="" role="none">
                                                <span
                                                    class="text-white px-4 py-2 text-sm se-setting-item rounded-t-md h-10 flex items-center hover:bg-gray-700"
                                                    role="menuitem" tabindex="-1" id="setting-item-0">${"🏆 Your profile"}</span>
                                                <span class="text-white px-4 py-2 text-sm se-setting-item h-10 flex items-center hover:bg-gray-700"
                                                    role="menuitem" tabindex="-1" id="setting-item-1">${"🔧 Settings"}</span>
                                                <span
                                                    class="text-white px-4 py-2 text-sm se-setting-item rounded-b-md h-10 flex items-center hover:bg-gray-700"
                                                    role="menuitem" tabindex="-1" id="setting-item-2">${"⛔ Log out"}</span>
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>                                
                            </div>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
        `;
    }

    #highlightSettingBtn() {
        this.#settingBtn.innerHTML = `
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0">
                <path fill-rule="evenodd" d="M11.078 2.25c-.917 0-1.699.663-1.85 1.567L9.05 4.889c-.02.12-.115.26-.297.348a7.493 7.493 0 00-.986.57c-.166.115-.334.126-.45.083L6.3 5.508a1.875 1.875 0 00-2.282.819l-.922 1.597a1.875 1.875 0 00.432 2.385l.84.692c.095.078.17.229.154.43a7.598 7.598 0 000 1.139c.015.2-.059.352-.153.43l-.841.692a1.875 1.875 0 00-.432 2.385l.922 1.597a1.875 1.875 0 002.282.818l1.019-.382c.115-.043.283-.031.45.082.312.214.641.405.985.57.182.088.277.228.297.35l.178 1.071c.151.904.933 1.567 1.85 1.567h1.844c.916 0 1.699-.663 1.85-1.567l.178-1.072c.02-.12.114-.26.297-.349.344-.165.673-.356.985-.57.167-.114.335-.125.45-.082l1.02.382a1.875 1.875 0 002.28-.819l.923-1.597a1.875 1.875 0 00-.432-2.385l-.84-.692c-.095-.078-.17-.229-.154-.43a7.614 7.614 0 000-1.139c-.016-.2.059-.352.153-.43l.84-.692c.708-.582.891-1.59.433-2.385l-.922-1.597a1.875 1.875 0 00-2.282-.818l-1.02.382c-.114.043-.282.031-.449-.083a7.49 7.49 0 00-.985-.57c-.183-.087-.277-.227-.297-.348l-.179-1.072a1.875 1.875 0 00-1.85-1.567h-1.843zM12 15.75a3.75 3.75 0 100-7.5 3.75 3.75 0 000 7.5z" clip-rule="evenodd" />
          </svg>
        `;
    }

    #unHighlightSettingBtn() {
        this.#settingBtn.innerHTML = `
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
                <path stroke-linecap="round" stroke-linejoin="round" d="M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.324.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 011.37.49l1.296 2.247a1.125 1.125 0 01-.26 1.431l-1.003.827c-.293.24-.438.613-.431.992a6.759 6.759 0 010 .255c-.007.378.138.75.43.99l1.005.828c.424.35.534.954.26 1.43l-1.298 2.247a1.125 1.125 0 01-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.57 6.57 0 01-.22.128c-.331.183-.581.495-.644.869l-.213 1.28c-.09.543-.56.941-1.11.941h-2.594c-.55 0-1.02-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 01-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 01-1.369-.49l-1.297-2.247a1.125 1.125 0 01.26-1.431l1.004-.827c.292-.24.437-.613.43-.992a6.932 6.932 0 010-.255c.007-.378-.138-.75-.43-.99l-1.004-.828a1.125 1.125 0 01-.26-1.43l1.297-2.247a1.125 1.125 0 011.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.087.22-.128.332-.183.582-.495.644-.869l.214-1.281z" />
                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
            </svg>
        `;
    }

    // #enableDarkMode() {
    //     this.#darkModeBtn.innerHTML = `
    //     <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0">
    //         <path fill-rule="evenodd" d="M9.528 1.718a.75.75 0 01.162.819A8.97 8.97 0 009 6a9 9 0 009 9 8.97 8.97 0 003.463-.69.75.75 0 01.981.98 10.503 10.503 0 01-9.694 6.46c-5.799 0-10.5-4.701-10.5-10.5 0-4.368 2.667-8.112 6.46-9.694a.75.75 0 01.818.162z" clip-rule="evenodd" />
    //     </svg>
    //     `;
    //
    // }

    // #disableDarkMode() {
    //     this.#darkModeBtn.innerHTML = `
    //     <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 shrink-0">
    //         <path stroke-linecap="round" stroke-linejoin="round" d="M21.752 15.002A9.718 9.718 0 0118 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 003 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 009.002-5.998z" />
    //     </svg> 
    //     `;
    // 
    // }
}

customElements.define("admin-sidebar", AdminSidebarComponent);