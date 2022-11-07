import logo from './logo.svg';
import './App.css';
import Accordion from 'react-bootstrap/Accordion';

function App() {
  const empty = []
  const requirements = ['Functional', 'Design']

  return (
    <div className='container-fluid p-4'>
      <h1>Systems</h1>
      <div className='container-fluid'>
        <div className='row'>
          <div className='col'>
            <System name='A' requirements={requirements}/>
          </div>
          <div className='col'>
            <System name='B' requirements={empty}/>
          </div>
        </div>

        <div className='row'>
          <div className='col'>
            <System name='C' requirements={empty}/>
          </div>
          <div className='col'>
            <System name='D' requirements={empty}/>
          </div>
        </div>

      </div>
    </div>
  );
}

function System(props) {
  const requirements = props.requirements;
  const buttons = requirements.map((req) => 
    <div className='mb-1'>
      <div className='btn btn-primary'>Trigger {req} Change</div>
    </div>  
  );

  return (
    <div className='card m-3'>
      <div className='card-header'><h2>System {props.name}</h2></div>
      <div className='card-body'>
        Stuff about it here
        <br/>
        <br/>
        <Accordion>
          <Accordion.Item eventKey="0">
            <Accordion.Header>Logs</Accordion.Header>
            <Accordion.Body>
              <textarea className='form-control' rows="5"></textarea>
            </Accordion.Body>
          </Accordion.Item>
        </Accordion>
      </div>
      <div className='card-footer'>
        {buttons}
      </div>
    </div>
  );
}

export default App;
