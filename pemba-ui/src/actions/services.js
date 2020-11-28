import axios from "axios";
const baseUrl = "http://localhost:44321/api/";

export default {

    dCandidate(url = baseUrl + 'dcandidate/') {

        // crud Methods
        
        return {
            create: newRecord => axios.post(url, newRecord),
            fetchAll: () => axios.get(url),
            fetchById: id => axios.get(url + id),

            update: (id, updateRecord) => axios.put(url + id, updateRecord),
            delete: id => axios.delete(url + id)
        }
    }
}