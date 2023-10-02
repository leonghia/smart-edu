export class StudentHomeFeatureComponent extends HTMLElement {

    #featureWrapper;
    #main;

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#featureWrapper = this.querySelector(".feature-wrapper");
        this.#main = document.querySelector(".main-wrapper");

        this.#featureWrapper.addEventListener("click", event => {
            const clicked = event.target.closest("a");
            if (!clicked) return;
            const id = Number(clicked.id.slice(-1));
            switch (id) {
                case 0:
                    this.#main.innerHTML = "<academic-progress></academic-progress>";
                    break;
                case 1:
                    this.#main.innerHTML = "<student-ma><student-ma/>";
                    break;
                case 2:
                    this.#main.innerHTML = "<timetable-schedule><timetable-schedule/>";
                    break;
                case 3:
                    this.#main.innerHTML = "<student-ec><student-ec/>";
                    break;
                case 4:
                    this.#main.innerHTML = "<student-doc><student-doc/>";
                    break;
                default:
                    console.log("default");
                    break;
            }
        });
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="bg-white">
        <div class="py-16 sm:py-24 xl:mx-auto xl:max-w-7xl xl:px-8">
            <div class="px-4 sm:flex sm:items-center sm:justify-between sm:px-6 lg:px-8 xl:px-0">
                <h2 class="text-2xl font-bold tracking-tight text-gray-900">What do you want to do?</h2>
                <a href="#" class="hidden text-sm font-semibold text-fuchsia-600 hover:text-fuchsia-500 sm:block">
                    Browse all features
                    <span aria-hidden="true"> &rarr;</span>
                </a>
            </div>
    
            <div class="mt-4 flow-root">
                <div class="-my-2">
                    <div class="relative box-content h-80 overflow-x-auto py-2 xl:overflow-visible">
                        <div
                            class="feature-wrapper absolute flex space-x-8 px-4 sm:px-6 lg:px-8 xl:relative xl:grid xl:grid-cols-5 xl:gap-x-8 xl:space-x-0 xl:px-0">
                            <a href="#" id="feature_0"
                                class="relative flex h-80 w-56 flex-col overflow-hidden rounded-lg p-6 hover:opacity-75 xl:w-auto">
                                <span aria-hidden="true" class="absolute inset-0">
                                    <img src="https://img.freepik.com/free-photo/young-man-learning-virtual-classroom_23-2149200188.jpg"
                                        alt="" class="h-full w-full object-cover object-center">
                                </span>
                                <span aria-hidden="true"
                                    class="absolute inset-x-0 bottom-0 h-2/3 bg-gradient-to-t from-gray-800 opacity-80"></span>
                                <span class="relative mt-auto text-center text-xl font-bold text-white">Academic</span>
                            </a>
                            <a href="#" id="feature_1"
                                class="relative flex h-80 w-56 flex-col overflow-hidden rounded-lg p-6 hover:opacity-75 xl:w-auto">
                                <span aria-hidden="true" class="absolute inset-0">
                                    <img src="https://www.usnews.com/object/image/00000142-9284-d33c-abc6-ff9537d20006/47786widemodern_SAT_092613.jpg?update-time=&size=responsive640"
                                        alt="" class="h-full w-full object-cover object-center">
                                </span>
                                <span aria-hidden="true"
                                    class="absolute inset-x-0 bottom-0 h-2/3 bg-gradient-to-t from-gray-800 opacity-80"></span>
                                <span class="relative mt-auto text-center text-xl font-bold text-white">Mark Tables</span>
                            </a>
                            <a href="#" id="feature_2"
                                class="relative flex h-80 w-56 flex-col overflow-hidden rounded-lg p-6 hover:opacity-75 xl:w-auto">
                                <span aria-hidden="true" class="absolute inset-0">
                                    <img src="https://www.guidingtech.com/wp-content/uploads/best-sticky-notes-productivity-tips-for-windows-10-2_4d470f76dc99e18ad75087b1b8410ea9.jpg"
                                        alt="" class="h-full w-full object-cover object-center">
                                </span>
                                <span aria-hidden="true"
                                    class="absolute inset-x-0 bottom-0 h-2/3 bg-gradient-to-t from-gray-800 opacity-80"></span>
                                <span class="relative mt-auto text-center text-xl font-bold text-white">Timetables</span>
                            </a>
                            <a href="#" id="feature_3"
                                class="relative flex h-80 w-56 flex-col overflow-hidden rounded-lg p-6 hover:opacity-75 xl:w-auto">
                                <span aria-hidden="true" class="absolute inset-0">
                                    <img src="https://media.wired.com/photos/63d1b65584464089ca2fc5fb/master/w_2560%2Cc_limit/ChatGPT-Is-Coming-To-Classrooms-Business-1298396060.jpg"
                                        alt="" class="h-full w-full object-cover object-center">
                                </span>
                                <span aria-hidden="true"
                                    class="absolute inset-x-0 bottom-0 h-2/3 bg-gradient-to-t from-gray-800 opacity-80"></span>
                                <span class="relative mt-auto text-center text-xl font-bold text-white">Extra Classes</span>
                            </a>
                            <a href="#" id="feature_4"
                                class="relative flex h-80 w-56 flex-col overflow-hidden rounded-lg p-6 hover:opacity-75 xl:w-auto">
                                <span aria-hidden="true" class="absolute inset-0">
                                    <img src="https://tailwindui.com/img/ecommerce-images/home-page-01-collection-03.jpg"
                                        alt="" class="h-full w-full object-cover object-center">
                                </span>
                                <span aria-hidden="true"
                                    class="absolute inset-x-0 bottom-0 h-2/3 bg-gradient-to-t from-gray-800 opacity-80"></span>
                                <span class="relative mt-auto text-center text-xl font-bold text-white">Resources</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
    
            <div class="mt-6 px-4 sm:hidden">
                <a href="#" class="block text-sm font-semibold text-fuchsia-600 hover:text-fuchsia-500">
                    Browse all features
                    <span aria-hidden="true"> &rarr;</span>
                </a>
            </div>
        </div>
    </div>        
        `;
    }
}

customElements.define("sh-feature", StudentHomeFeatureComponent);