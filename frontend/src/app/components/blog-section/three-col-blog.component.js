export class ThreeColumnBlogComponent extends HTMLElement {
    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="bg-white py-8 sm:py-16">
        <div class="mx-auto max-w-7xl px-6 lg:px-8">
            <div class="mx-auto max-w-2xl text-center">
                <h2 class="text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">From students and teachers</h2>
                <p class="mt-2 text-lg leading-8 text-gray-600">Learn how to grow your academic with our students and teachers' advice</p>
            </div>
            <div class="mx-auto mt-16 grid max-w-2xl grid-cols-1 gap-x-8 gap-y-20 lg:mx-0 lg:max-w-none lg:grid-cols-3">
                <article class="flex flex-col items-start justify-between">
                    <div class="relative w-full">
                        <img src="https://images.unsplash.com/photo-1496128858413-b36217c2ce36?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=3603&q=80"
                            alt=""
                            class="aspect-[16/9] w-full rounded-2xl bg-gray-100 object-cover sm:aspect-[2/1] lg:aspect-[3/2]">
                        <div class="absolute inset-0 rounded-2xl ring-1 ring-inset ring-gray-900/10"></div>
                    </div>
                    <div class="max-w-xl">
                        <div class="mt-8 flex items-center gap-x-4 text-xs">
                            <time datetime="2020-03-16" class="text-gray-500">Sep 16, 2023</time>
                            <a href="#"
                                class="relative z-10 rounded-full bg-gray-50 px-3 py-1.5 font-medium text-gray-600 hover:bg-gray-100">Academic</a>
                        </div>
                        <div class="group relative">
                            <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                                <a href="#">
                                    <span class="absolute inset-0"></span>
                                    Boost your exam score performance
                                </a>
                            </h3>
                            <p class="mt-5 line-clamp-3 text-sm leading-6 text-gray-600">Illo sint voluptas. Error
                                voluptates culpa eligendi. Hic vel totam vitae illo. Non aliquid explicabo necessitatibus
                                unde. Sed exercitationem placeat consectetur nulla deserunt vel. Iusto corrupti dicta.</p>
                        </div>
                        <div class="relative mt-8 flex items-center gap-x-4">
                            <img src="https://we25.vn/media2018/Img_News/2020/09/22/ban-cung-ban-nghi-hoc-nam-sinh-lam-hinh-ve-sieu-kute-the-cho-dan-tinh-dua-nhau-tag-ban-va-phat-hien-trai-dep-2_20200922180212.jpg"
                                alt="" class="h-10 w-10 rounded-full bg-gray-100">
                            <div class="text-sm leading-6">
                                <p class="font-semibold text-gray-900">
                                    <a href="#">
                                        <span class="absolute inset-0"></span>
                                        Nguyen Trung Duc
                                    </a>
                                </p>
                                <p class="text-gray-600">Student / Class 10A</p>
                            </div>
                        </div>
                    </div>
                </article>

                

                <article class="flex flex-col items-start justify-between">
                    <div class="relative w-full">
                        <img src="https://images.unsplash.com/photo-1547586696-ea22b4d4235d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=3270&q=80"
                            alt=""
                            class="aspect-[16/9] w-full rounded-2xl bg-gray-100 object-cover sm:aspect-[2/1] lg:aspect-[3/2]">
                        <div class="absolute inset-0 rounded-2xl ring-1 ring-inset ring-gray-900/10"></div>
                    </div>
                    <div class="max-w-xl">
                        <div class="mt-8 flex items-center gap-x-4 text-xs">
                            <time datetime="2020-03-16" class="text-gray-500">Sep 16, 2023</time>
                            <a href="#"
                                class="relative z-10 rounded-full bg-gray-50 px-3 py-1.5 font-medium text-gray-600 hover:bg-gray-100">Academic</a>
                        </div>
                        <div class="group relative">
                            <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                                <a href="#">
                                    <span class="absolute inset-0"></span>
                                    How to use AI tools to leverage your learning
                                </a>
                            </h3>
                            <p class="mt-5 line-clamp-3 text-sm leading-6 text-gray-600">Optio cum necessitatibus dolor voluptatum provident commodi et. Qui aperiam fugiat nemo cumque.</p>
                        </div>
                        <div class="relative mt-8 flex items-center gap-x-4">
                            <img src="https://ttol.vietnamnetjsc.vn//2017/08/03/14/36/chan-dung-chang-thu-khoa-truong-y-khac-xa-voi-tuong-tuong-cua-so-dong_1.jpg"
                                alt="" class="h-10 w-10 rounded-full bg-gray-100">
                            <div class="text-sm leading-6">
                                <p class="font-semibold text-gray-900">
                                    <a href="#">
                                        <span class="absolute inset-0"></span>
                                        Pham Duc Hoang
                                    </a>
                                </p>
                                <p class="text-gray-600">Student / Class 11C</p>
                            </div>
                        </div>
                    </div>
                </article>

                <article class="flex flex-col items-start justify-between">
                    <div class="relative w-full">
                        <img src="https://images.unsplash.com/photo-1492724441997-5dc865305da7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=3270&q=80"
                            alt=""
                            class="aspect-[16/9] w-full rounded-2xl bg-gray-100 object-cover sm:aspect-[2/1] lg:aspect-[3/2]">
                        <div class="absolute inset-0 rounded-2xl ring-1 ring-inset ring-gray-900/10"></div>
                    </div>
                    <div class="max-w-xl">
                        <div class="mt-8 flex items-center gap-x-4 text-xs">
                            <time datetime="2020-03-16" class="text-gray-500">Sep 16, 2023</time>
                            <a href="#"
                                class="relative z-10 rounded-full bg-gray-50 px-3 py-1.5 font-medium text-gray-600 hover:bg-gray-100">Experience</a>
                        </div>
                        <div class="group relative">
                            <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                                <a href="#">
                                    <span class="absolute inset-0"></span>
                                    Improve your school experience
                                </a>
                            </h3>
                            <p class="mt-5 line-clamp-3 text-sm leading-6 text-gray-600">Cupiditate maiores ullam eveniet adipisci in doloribus nulla minus. Voluptas iusto libero adipisci rem et corporis. Nostrud sint anim sunt aliqua. Nulla eu labore irure incididunt velit cillum quis magna dolore.</p>
                        </div>
                        <div class="relative mt-8 flex items-center gap-x-4">
                            <img src="https://cdn.baoquocte.vn/stores/news_dataimages/yennguyet/022017/09/16/161352_16508498_1244470032307032_3396164285174000811_n.jpg"
                                alt="" class="h-10 w-10 rounded-full bg-gray-100">
                            <div class="text-sm leading-6">
                                <p class="font-semibold text-gray-900">
                                    <a href="#">
                                        <span class="absolute inset-0"></span>
                                        Dao Duong Minh
                                    </a>
                                </p>
                                <p class="text-gray-600">Teacher / Maths subject</p>
                            </div>
                        </div>
                    </div>
                </article>
    
                <!-- More posts... -->
            </div>
        </div>
    </div>    
        `;
    }
}

customElements.define("three-col-blog", ThreeColumnBlogComponent);