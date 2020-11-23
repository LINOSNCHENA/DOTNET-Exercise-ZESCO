import React, { Component } from 'react';
import { Col, Container, Row } from 'reactstrap';
import DataTable from './DataTable';
import RegistrationModal from './form/AddOrEditBanker';
import { URL1 } from '../services';
class Home extends Component {
  state = {
    items: []
  }
  componentDidMount() {
    this.getItens();
  }
  getItens = () => {
    fetch(URL1)
      .then(res => res.json())
      .then(res => this.setState({ items: res }))
      .catch(err => console.log(err));
  }
  addUserToState = user => {
    this.setState(previous => ({
      items: [...previous.items, user]
    }));
  }
  updateState = (id) => {
    this.getItens();
  }
  deleteItemFromState = id => {
    const updated = this.state.items.filter(item => item.id !== id);
    this.setState({ items: updated })
  }
  render() {
    return <Container style={{ paddingTop: "100px" }}>
      <Row>
        <Col>
        <h3 class="headerzanaco">     ZANACO BANK CLIENTS LISTING IN ZESCO</h3>
        </Col>
      </Row>
      <Row>
        <Col>
          <DataTable
            items={this.state.items}
            updateState={this.updateState}
            deleteItemFromState={this.deleteItemFromState} />
        </Col>
      </Row>
      <Row>
        <Col>
          <RegistrationModal isNew={true} addUserToState={this.addUserToState} />
        </Col>
      </Row>
    </Container>;
  }
}
export default Home;