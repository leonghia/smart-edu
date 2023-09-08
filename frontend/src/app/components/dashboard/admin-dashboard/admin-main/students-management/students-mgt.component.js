import { formatDate } from "../../../../../helpers/datetime.helper.js";

export class StudentsMgtComponent extends HTMLElement {
    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        const tableBody = document.querySelector("tbody");
        Promise.resolve(new Array())
            .then(data => {
                for (let i = 0; i < 100; i++) {
                    data.push(i);    
                }
                
                data.forEach((currentValue, currentIndex) => {
                    tableBody.insertAdjacentHTML("beforeend", this.#renderStudentsRow(currentValue, currentIndex));
                });
            });
    }

    disconnectedCallback() {

    }

    #render() {
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
                                        <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-white">Identifier</th>
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

    #renderStudentsRow(currentValue, currentIndex) {
        return `
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
                    <div class="hidden text-sm leading-6 text-gray-400 sm:block">${true ? "Online" : "Offline"}</div>
                </div>
            </td>
            <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-400">${"10A"}</td>
            <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-400">${formatDate("2004-03-26T00:00:00")}</td>
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
                                    <div class="hidden text-sm leading-6 text-gray-400 sm:block">${true ? "Online" : "Offline"}</div>
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
                        tableBody.insertAdjacentHTML("beforeend", resultMarkup);
                    })

                });

                let markup;
                data.forEach((currentValue, currentIndex) => {
                    markup = `
                    
                    `;
                    tableBody.insertAdjacentHTML("beforeend", markup);
                })
            });
    }
}

customElements.define("students-mgt", StudentsMgtComponent);

