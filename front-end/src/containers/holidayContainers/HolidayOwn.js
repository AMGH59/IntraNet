import { faBackspace, faPencilAlt, faSpinner, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React, { PureComponent } from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import HolidayCard from '../../components/holidayComponents/HolidayCard';
import HolidayForm from '../../components/holidayComponents/HolidayForm';
import ButtonComponent from '../../components/toolComponents/ButtonComponent';
import { getHolidaysFromApi } from '../../redux/actions/holidayAction';
import { getUser } from '../../redux/actions/userAction';
import { deleteHolidayApi } from '../../services/holidayData';

class HolidayOwn extends PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            showUpdateForm: false,
            holidaySelected: undefined
        }
    }


    componentDidMount = async () => {
        await this.props.getUser();
        this.props.getAllHolidaysFromApi();
    }

    handleDelete = async (id) => {
        // e.preventDefault();
        // let url = window.location.pathname.slice(9);
        await deleteHolidayApi(id).then(res => {
            this.setState({
                post: "",
                deleted: true
            })
        })
        window.location.reload(false)
        // window.location.assign("http://localhost:3000/holiday/list");
    }

    updateClickOpenForm = async (holiday) => {
        this.setState({
            showUpdateForm: true,
            holidaySelected: holiday
        })
    }
    updateClickCloseForm = async () => {
        this.setState({
            showUpdateForm: false
        })
    }

    render() {
        return (
            <div>
                <div>
                    <Link to="/holiday"><ButtonComponent type="button" color="bg-indigo-500" colorText="white" body="Retour" logo={faBackspace} /></Link>
                </div>
                <div className="flex items-center justify-center bg-white">
                    <div className="flex flex-col">
                        <div className={`flex flex-wrap justify-center items-center space-x-4 ${this.props.isLoading ? null : "invisible"}`}>
                            <FontAwesomeIcon icon={faSpinner} className="animate-spin text-2xl" />
                        </div>

                        <div className="flex flex-col">
                            <div className="text-gray-400 font-bold uppercase text-center">
                                Historique des demande de congés en cours
                            </div>
                            <div className="flex flex-row flex-wrap justify-around">
                                {this.props.user.user != undefined && this.props.user.user.id && this.props.holidays.filter(h => h.collaboratorId == this.props.user.user.id) ?
                                    this.props.holidays.filter(h => h.collaboratorId == this.props.user.user.id).map(filteredHoliday => (
                                        // <Link to={`/holiday/${filteredHoliday.id}`} key={filteredHoliday.id}>
                                        <div key={filteredHoliday.id}>
                                            <HolidayCard post={filteredHoliday} />
                                            <div className="flex justify-center">
                                                <ButtonComponent type="button" color="bg-red-400" colorText="white"
                                                    logo={faTrashAlt}
                                                    onClickMethod={() => this.handleDelete(filteredHoliday.id)} />
                                                <ButtonComponent type="button" color="bg-indigo-400" colorText="white"
                                                    logo={faPencilAlt}
                                                    onClickMethod={() => this.updateClickOpenForm(filteredHoliday)} />
                                            </div>
                                        </div>
                                        /* </Link> */
                                        ))
                                    : null}
                            </div>
                                    {this.state.showUpdateForm == true ? <HolidayForm holiday={this.state.holidaySelected} updateClickCloseForm={this.updateClickCloseForm} /> : null}
                        </div>
                    </div>
                </div>

            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        holidays: state.holidayState.holidays,
        isLoading: state.holidayState.isLoading,
        user: state.user
    }
}
const mapActionToProps = (dispatch) => {
    return {
        getAllHolidaysFromApi: () => dispatch(getHolidaysFromApi()),
        getUser: () => dispatch(getUser())
    }
}

export default connect(mapStateToProps, mapActionToProps)(HolidayOwn);