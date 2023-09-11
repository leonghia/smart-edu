import EventService from "../../services/event.service.js";

class SearchBarService extends EventService {

    constructor() {
        super({search: []});
    }
}

export default new SearchBarService();