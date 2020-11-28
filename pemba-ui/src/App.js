import './App.css';
import React from 'react';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import DCandidates from './components/DCandidates';
import { Container } from "@material-ui/core";
import { ToastProvider } from "react-toast-notifications";

function App() {
  return (
    <Provider store={store}>
      <ToastProvider autoDismiss={true}>
        <Container maxWidth="lg">

        <React.StrictMode>
          <DCandidates />
          </React.StrictMode>
          
        </Container>
      </ToastProvider>
    </Provider>
  );
}
///  </React.StrictMode>

export default App;
