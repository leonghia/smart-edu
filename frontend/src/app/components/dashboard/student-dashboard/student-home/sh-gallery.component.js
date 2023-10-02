export class StudentHomeGalleryComponent extends HTMLElement {


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
    <div class="overflow-hidden bg-white py-16">
        <div class="mx-auto max-w-7xl px-6 lg:flex lg:px-8">
            <div
                class="mx-auto grid max-w-2xl grid-cols-1 gap-x-12 gap-y-16 lg:mx-0 lg:min-w-full lg:max-w-none lg:flex-none lg:gap-y-8">
                <div class="lg:col-end-1 lg:w-full lg:max-w-lg lg:pb-8">
                    <h2 class="text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">Our school</h2>
                    <p class="mt-6 text-xl leading-8 text-gray-600">Quasi est quaerat. Sit molestiae et. Provident ad
                        dolorem occaecati eos iste. Soluta rerum quidem minus ut molestiae velit error quod. Excepturi
                        quidem expedita molestias quas.</p>
                    <p class="mt-6 text-base leading-7 text-gray-600">Anim aute id magna aliqua ad ad non deserunt sunt. Qui
                        irure qui lorem cupidatat commodo. Elit sunt amet fugiat veniam occaecat fugiat. Quasi aperiam sit
                        non sit neque reprehenderit.</p>                
                </div>
                <div class="flex flex-wrap items-start justify-end gap-6 sm:gap-8 lg:contents">
                    <div class="w-0 flex-auto lg:ml-auto lg:w-auto lg:flex-none lg:self-end">
                        <img src="https://st.ielts-fighter.com/src/ielts-fighter/2021/03/16/truong-thpt-chu-van-an-2.jpg"
                            alt="" class="aspect-[7/5] w-[37rem] max-w-none rounded-2xl bg-gray-50 object-cover">
                    </div>
                    <div
                        class="contents lg:col-span-2 lg:col-end-2 lg:ml-auto lg:flex lg:w-[37rem] lg:items-start lg:justify-end lg:gap-x-8">
                        <div class="order-first flex w-64 flex-none justify-end self-end lg:w-auto">
                            <img src="https://images2.thanhnien.vn/528068263637045248/2023/8/23/lop-chuyen-16927906596071157869408.png"
                                alt=""
                                class="aspect-[4/3] w-[24rem] max-w-none flex-none rounded-2xl bg-gray-50 object-cover">
                        </div>
                        <div class="flex w-96 flex-auto justify-end lg:w-auto lg:flex-none">
                            <img src="https://edusmart.vn/wp-content/uploads/2020/06/truong-thpt-chu-van-an-ha-noi-1.jpg"
                                alt=""
                                class="aspect-[7/5] w-[37rem] max-w-none flex-none rounded-2xl bg-gray-50 object-cover">
                        </div>
                        <div class="hidden sm:block sm:w-0 sm:flex-auto lg:w-auto lg:flex-none">
                            <img src="https://c3chuvanan.edu.vn/wp-content/uploads/2019/09/khai-giang-1-1567658918570.jpg"
                                alt="" class="aspect-[4/3] w-[24rem] max-w-none rounded-2xl bg-gray-50 object-cover">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    
        `;
    }
}

customElements.define("sh-gallery", StudentHomeGalleryComponent);