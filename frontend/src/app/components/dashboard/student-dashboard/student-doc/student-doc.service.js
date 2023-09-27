import EventService from "../../../../services/event.service";

class StudentDocumentService extends EventService {

    constructor() {
        super({
            totalPages: [],
            next: [],
            prev: [],
            displayFilterResult: []
        });
    }
}

export default new StudentDocumentService();