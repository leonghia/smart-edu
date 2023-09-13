import EventService from "../../../../../services/event.service.js";

class StudentsMgtService extends EventService {
    constructor() {
        super({showAddModal: []});
    }
}

export default new StudentsMgtService();