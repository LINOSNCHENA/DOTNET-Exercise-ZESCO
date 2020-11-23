import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

class Table extends Component {
  constructor(props) {
    super(props);
  }

  DeleteStudent = () => {
    axios.delete('https://localhost:44362/students/StudentDelete?id=' + this.props.obj.Id)
      .then(json => {
        if (json.data.Status === 'Delete') {
          alert('Record deleted successfully!!');
        }
      })
  }


  /////////////
  render() {
    const items = this.props;
    console.log("Beginning");
    console.log(items.obj.Name)
    console.log(items.Name)
    console.log(items);
    console.log("Ending");
    return (
      <tr>
        <td>
          {this.props.obj.Name}
        </td>
        <td>
          {this.props.obj.RollNo}
        </td>
        <td>
          {this.props.obj.Class}
        </td>
        <td>
          {this.props.obj.Address}
        </td>

        {/* /////////////////////////////////////// */}
        {/* {this.props.obj.map(item => {
                        return <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.name}</td>
                            <td>{item.rollno}</td>
                            <td>{item.class}</td>
                            <td>{item.address}</td>

                        </tr>
                    })} */}
        <td>
          <Link to={"/edit/" + this.props.obj.Id}
            className="btn btn-success">Edit1</Link>
        </td>
        <td>
          <Link to={"/edit/" + this.props.obj.Id}
            className="btn btn-success">Edit2</Link>
        </td>
        <td>
          <Link to={"/edit/" + this.props.obj.Id}
            className="btn btn-success">Edit3</Link>
        </td>
         <td>{items.RollNo}</td>
        <td>{items.Name}</td>
        <td>
          <Link to={"/edit/" + this.props.obj.Id}
            className="btn btn-success">Edit</Link>
        </td>
        <td>
          <button type="button" onClick={this.DeleteStudent}
            className="btn btn-danger">Delete</button>
        </td>
      </tr>
    );
  }
}


export default Table;  