import EventService from "../../services/event.service";

class PaginationService extends EventService {
    constructor(){
        super({
            reset: [],
        });
        
    }
}

export default new PaginationService();