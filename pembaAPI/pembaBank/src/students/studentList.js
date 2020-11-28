import React, { useState, useEffect } from 'react'
import axios from 'axios';
function Employeedata() {
    const [data, setData] = useState([]);

    useEffect(() => {
        //        debugger;  
        axios.get('https://localhost:44362/students/studentdetails')
            .then(result => setData(result.data));
        console.log(data);
        //     debugger;  
    }, []);
    return (
        <div>
            <div className="row" style={{ 'margin': "10px" }}>
                <div className="col-sm-12 btn btn-info">
                    Bankers: How to fetch data Using React Hooks
                 </div>
            </div>
            <table class="table" >
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">No.</th>
                        <th scope="col">Name</th>
                        <th scope="col">Row No.</th>
                        <th scope="col">Class</th>
                        <th scope="col">Address</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(item => {
                        return <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.name}</td>
                            <td>{item.rollno}</td>
                            <td>{item.class}</td>
                            <td>{item.address}</td>
                        </tr>
                    })}
                </tbody>
            </table>

        </div>
    )
}

export default Employeedata