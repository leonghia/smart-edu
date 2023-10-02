export class StudentHomeComponent extends HTMLElement {
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
    <div
        class="relative overflow-hidden bg-gray-900 px-6 py-20 shadow-xl sm:rounded-3xl sm:px-10 sm:py-24 md:px-12 lg:px-20">
        <img class="absolute inset-0 h-full w-full object-cover"
            src="https://i1-vnexpress.vnecdn.net/2018/11/03/1-1541231744.jpg?w=0&h=0&q=100&dpr=2&fit=crop&s=ZfwKdD5wf4VJiiRp0aeRXQ"
            alt="">
        <div class="absolute inset-0 bg-gray-900/90 mix-blend-multiply"></div>
        <div class="absolute -left-80 -top-56 transform-gpu blur-3xl" aria-hidden="true">
            <div class="aspect-[1097/845] w-[68.5625rem] bg-gradient-to-r from-[#ff4694] to-[#776fff] opacity-[0.45]"
                style="clip-path: polygon(74.1% 44.1%, 100% 61.6%, 97.5% 26.9%, 85.5% 0.1%, 80.7% 2%, 72.5% 32.5%, 60.2% 62.4%, 52.4% 68.1%, 47.5% 58.3%, 45.2% 34.5%, 27.5% 76.7%, 0.1% 64.9%, 17.9% 100%, 27.6% 76.8%, 76.1% 97.7%, 74.1% 44.1%)">
            </div>
        </div>
        <div class="hidden md:absolute md:bottom-16 md:left-[50rem] md:block md:transform-gpu md:blur-3xl"
            aria-hidden="true">
            <div class="aspect-[1097/845] w-[68.5625rem] bg-gradient-to-r from-[#ff4694] to-[#776fff] opacity-25"
                style="clip-path: polygon(74.1% 44.1%, 100% 61.6%, 97.5% 26.9%, 85.5% 0.1%, 80.7% 2%, 72.5% 32.5%, 60.2% 62.4%, 52.4% 68.1%, 47.5% 58.3%, 45.2% 34.5%, 27.5% 76.7%, 0.1% 64.9%, 17.9% 100%, 27.6% 76.8%, 76.1% 97.7%, 74.1% 44.1%)">
            </div>
        </div>
        <div class="relative mx-auto max-w-2xl lg:mx-0">
            <h2 class="text-2xl font-bold leading-7 text-white sm:truncate sm:text-3xl sm:tracking-tight">Chu Van An high school</h2>
            <figure>
                <blockquote class="mt-6 text-lg font-light text-white sm:text-xl sm:leading-8">
                    <p>“Established in 1908, Chu Van An high school has a proud tradition offer our diverse school population a wide range of academic, cultural and sporting opportunities. The school combines modern facilities and a progressive education programme with traditional core values.”</p>
                </blockquote>
                <figcaption class="mt-6 text-base text-white">
                    <div class="font-semibold">Mrs. Nguyen Thi Nhiep</div>
                    <div class="mt-1">Principal</div>
                </figcaption>
            </figure>
        </div>
    </div>
    <sh-feature></sh-feature>  
    <sh-gallery></sh-gallery>
    <three-col-blog></three-col-blog>   
        `;
    }
}

customElements.define("student-home", StudentHomeComponent);