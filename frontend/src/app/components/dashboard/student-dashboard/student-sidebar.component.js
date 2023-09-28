import studentEcService from "./student-ec/student-ec.service";
import studentSidebarService from "./student-sidebar.service";

export class StudentSidebarComponent extends HTMLElement {

    #sidebar;
    #sidebarContainer;

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#sidebar = document.querySelector(".sidebar");
        this.#sidebarContainer = document.querySelector(".sidebar-container");
        
        this.#sidebarContainer.addEventListener("click", function (event) {
            
            const clicked = event.target.closest("a");
            if (!clicked) {
                return;
            }
            const links = this.#sidebarContainer.querySelectorAll("a");
            links.forEach(a => {
                a.classList.remove(..."bg-gray-600 text-white".split(" "));
                a.classList.add(..."text-gray-400 hover:text-white hover:bg-gray-600".split(" "));
            });
            clicked.classList.remove(..."text-gray-400 hover:text-white hover:bg-gray-600".split(" "));
            clicked.classList.add(..."bg-gray-600 text-white".split(" "));
            const tempArr = clicked.id.split("_");
            const id = Number(tempArr[tempArr.length - 1]);
            studentSidebarService.trigger("switch", id);
        }.bind(this));
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div
        class="hidden lg:fixed lg:inset-y-0 lg:left-0 lg:z-50 lg:block lg:w-20 lg:overflow-y-auto bg-gray-700 lg:pb-4 sidebar">
        <div class="flex h-16 shrink-0 items-center justify-center">
            <img class="h-8 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=fuchsia&shade=500"
                alt="Your Company">
        </div>
        <nav class="mt-8">
            <ul role="list" class="flex flex-col items-center space-y-1 sidebar-container">
                <li>
                    <!-- Current: "bg-gray-800 text-white", Default: "text-gray-400 hover:text-white hover:bg-gray-800" -->
                    <a href="#" id="sidebar_item_0"
                        class="text-white bg-gray-600 hover:text-white hover:bg-gray-600 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-3 text-sm leading-6 font-semibold">               
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0 text-amber-500">
                            <path d="M11.47 3.84a.75.75 0 011.06 0l8.69 8.69a.75.75 0 101.06-1.06l-8.689-8.69a2.25 2.25 0 00-3.182 0l-8.69 8.69a.75.75 0 001.061 1.06l8.69-8.69z" />
                            <path d="M12 5.432l8.159 8.159c.03.03.06.058.091.086v6.198c0 1.035-.84 1.875-1.875 1.875H15a.75.75 0 01-.75-.75v-4.5a.75.75 0 00-.75-.75h-3a.75.75 0 00-.75.75V21a.75.75 0 01-.75.75H5.625a1.875 1.875 0 01-1.875-1.875v-6.198a2.29 2.29 0 00.091-.086L12 5.43z" />
                        </svg>
                        <span class="sr-only">Home</span>
                    </a>
                </li>
                <li>
                    <a href="#" id="sidebar_item_1"
                        class="text-gray-400 hover:text-white hover:bg-gray-600 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-3 text-sm leading-6 font-semibold">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0 text-pink-500">
                            <path fill-rule="evenodd" d="M3 6a3 3 0 013-3h12a3 3 0 013 3v12a3 3 0 01-3 3H6a3 3 0 01-3-3V6zm4.5 7.5a.75.75 0 01.75.75v2.25a.75.75 0 01-1.5 0v-2.25a.75.75 0 01.75-.75zm3.75-1.5a.75.75 0 00-1.5 0v4.5a.75.75 0 001.5 0V12zm2.25-3a.75.75 0 01.75.75v6.75a.75.75 0 01-1.5 0V9.75A.75.75 0 0113.5 9zm3.75-1.5a.75.75 0 00-1.5 0v9a.75.75 0 001.5 0v-9z" clip-rule="evenodd" />
                        </svg>                   
                        <span class="sr-only">Academic progress</span>
                    </a>
                </li>
                <li>
                    <a href="#" id="sidebar_item_2"
                        class="text-gray-400 hover:text-white hover:bg-gray-600 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-3 text-sm leading-6 font-semibold">                    
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0 text-orange-500">
                            <path fill-rule="evenodd" d="M1.5 5.625c0-1.036.84-1.875 1.875-1.875h17.25c1.035 0 1.875.84 1.875 1.875v12.75c0 1.035-.84 1.875-1.875 1.875H3.375A1.875 1.875 0 011.5 18.375V5.625zM21 9.375A.375.375 0 0020.625 9h-7.5a.375.375 0 00-.375.375v1.5c0 .207.168.375.375.375h7.5a.375.375 0 00.375-.375v-1.5zm0 3.75a.375.375 0 00-.375-.375h-7.5a.375.375 0 00-.375.375v1.5c0 .207.168.375.375.375h7.5a.375.375 0 00.375-.375v-1.5zm0 3.75a.375.375 0 00-.375-.375h-7.5a.375.375 0 00-.375.375v1.5c0 .207.168.375.375.375h7.5a.375.375 0 00.375-.375v-1.5zM10.875 18.75a.375.375 0 00.375-.375v-1.5a.375.375 0 00-.375-.375h-7.5a.375.375 0 00-.375.375v1.5c0 .207.168.375.375.375h7.5zM3.375 15h7.5a.375.375 0 00.375-.375v-1.5a.375.375 0 00-.375-.375h-7.5a.375.375 0 00-.375.375v1.5c0 .207.168.375.375.375zm0-3.75h7.5a.375.375 0 00.375-.375v-1.5A.375.375 0 0010.875 9h-7.5A.375.375 0 003 9.375v1.5c0 .207.168.375.375.375z" clip-rule="evenodd" />
                        </svg>
                        <span class="sr-only">Mark tables</span>
                    </a>
                </li>
                <li>
                    <a href="#" id="sidebar_item_3"
                        class="text-gray-400 hover:text-white hover:bg-gray-600 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-3 text-sm leading-6 font-semibold">                      
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0 text-sky-500">
                            <path d="M12.75 12.75a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM7.5 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM8.25 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM9.75 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM10.5 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM12 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM12.75 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM14.25 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM15 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM16.5 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM15 12.75a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM16.5 13.5a.75.75 0 100-1.5.75.75 0 000 1.5z" />
                            <path fill-rule="evenodd" d="M6.75 2.25A.75.75 0 017.5 3v1.5h9V3A.75.75 0 0118 3v1.5h.75a3 3 0 013 3v11.25a3 3 0 01-3 3H5.25a3 3 0 01-3-3V7.5a3 3 0 013-3H6V3a.75.75 0 01.75-.75zm13.5 9a1.5 1.5 0 00-1.5-1.5H5.25a1.5 1.5 0 00-1.5 1.5v7.5a1.5 1.5 0 001.5 1.5h13.5a1.5 1.5 0 001.5-1.5v-7.5z" clip-rule="evenodd" />
                        </svg>
                        <span class="sr-only">Timetables and schedules</span>
                    </a>
                </li>
                <li>
                    <a href="#" id="sidebar_item_4"
                        class="text-gray-400 hover:text-white hover:bg-gray-600 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-3 text-sm leading-6 font-semibold">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0 text-green-500">
                            <path fill-rule="evenodd" d="M3 6a3 3 0 013-3h12a3 3 0 013 3v12a3 3 0 01-3 3H6a3 3 0 01-3-3V6zm14.25 6a.75.75 0 01-.22.53l-2.25 2.25a.75.75 0 11-1.06-1.06L15.44 12l-1.72-1.72a.75.75 0 111.06-1.06l2.25 2.25c.141.14.22.331.22.53zm-10.28-.53a.75.75 0 000 1.06l2.25 2.25a.75.75 0 101.06-1.06L8.56 12l1.72-1.72a.75.75 0 10-1.06-1.06l-2.25 2.25z" clip-rule="evenodd" />
                        </svg>                      
                        <span class="sr-only">Extra Classes</span>
                    </a>
                </li>
                <li>
                    <a href="#" id="sidebar_item_5"
                        class="text-gray-400 hover:text-white hover:bg-gray-600 dark:hover:bg-gray-800 group flex gap-x-3 rounded-md p-3 text-sm leading-6 font-semibold">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-6 h-6 shrink-0 text-violet-500">
                            <path d="M7.5 3.375c0-1.036.84-1.875 1.875-1.875h.375a3.75 3.75 0 013.75 3.75v1.875C13.5 8.161 14.34 9 15.375 9h1.875A3.75 3.75 0 0121 12.75v3.375C21 17.16 20.16 18 19.125 18h-9.75A1.875 1.875 0 017.5 16.125V3.375z" />
                            <path d="M15 5.25a5.23 5.23 0 00-1.279-3.434 9.768 9.768 0 016.963 6.963A5.23 5.23 0 0017.25 7.5h-1.875A.375.375 0 0115 7.125V5.25zM4.875 6H6v10.125A3.375 3.375 0 009.375 19.5H16.5v1.125c0 1.035-.84 1.875-1.875 1.875h-9.75A1.875 1.875 0 013 20.625V7.875C3 6.839 3.84 6 4.875 6z" />
                        </svg>
                        <span class="sr-only">Learning Materials</span>
                    </a>
                </li>
            </ul>
        </nav>
    </div>
        `;
    }
}

customElements.define("student-sidebar", StudentSidebarComponent);