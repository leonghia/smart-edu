export class MarkTableComponent extends HTMLElement {

    #tableBody;
    #subjectNames = ["Maths", "Literature", "English", "Physics", "Chemistry", "Biology", "Information Technology", "History", "Geography", "Civic Education", "Military Education", "Physical Education", "Japanese", "French"];

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#tableBody = this.querySelector("tbody");
        this.#displayRows();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="relative overflow-x-auto shadow-md sm:rounded-lg">
        <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-white uppercase bg-fuchsia-500 dark:bg-fuchsia-600">
                <tr>
                    <th scope="col" class="px-6 py-3 border-r border-dashed border-gray-400">
                        Subject name
                    </th>
                    <th scope="col" colspan="2" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        Oral test
                    </th>
                    <th scope="col" colspan="3" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        15-minute test
                    </th>
                    <th scope="col" colspan="2" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        45-minute-test
                    </th>
                    <th scope="col" colspan="1" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        Semester test
                    </th>
                    <th scope="col" colspan="1" class="text-center px-6 py-3 border-r border-dashed border-gray-400">
                        Average
                    </th>
                </tr>
            </thead>
            <tbody>
                           
            </tbody>
        </table>
    </div>          
        `;
    }

    #renderRow(subjectName) {
        return `
    <tr class="bg-white bg-opacity-70 border-b border-dashed border-gray-400 dark:bg-gray-800 dark:border-gray-700">
        <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white border-r border-dashed border-gray-400 dark:border-gray-700">
            ${subjectName}
        </th>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            9
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            7
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            5
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            8
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            9
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            8.6
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            9.2
        </td>
        <td class="text-center px-6 py-4 border-r border-dashed border-gray-400 dark:border-gray-700">
            9.4
        </td>
        <td class="text-center px-6 py-4 font-medium text-gray-800">
            8.8
        </td>
    </tr>  
        `;
    } 

    #displayRows() {
        this.#subjectNames.forEach(sN => this.#tableBody.insertAdjacentHTML("beforeend", this.#renderRow(sN)));
        this.#tableBody.lastElementChild.classList.remove(..."border-b border-dashed border-gray-400".split(" "));
    }
}

customElements.define("mark-table", MarkTableComponent);