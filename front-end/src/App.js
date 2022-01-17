import React from "react";
import {
    BrowserRouter as Router,
    Routes,
    Switch,
    Route,
} from "react-router-dom";
import './styles/index.css';
import AddMission from "./components/AddMission";
<<<<<<< HEAD
import BillsOverview from "./containers/BillsOverview"
// import BillsOverviewID from "./containers/BillsOverviewId"
=======
import BillsOverview from "./containers/BillsOverview";
import HolidayOverview from "./containers/HolidayOverview";

>>>>>>> Dev
function App() {
    return (
        <div className="App">
            <Router>
                <header className="header">
                    < AddMission />
                </header>
                <Routes>
                    <Route
                        path="bills"
                        element={<BillsOverview />}
                    />
                    <Route
                        path="holidays"
                        element={<HolidayOverview />}
                    />
                </Routes>
            </Router>
        </div>
    );
}

export default App;
