import { PureComponent, useEffect } from "react"
import { useParams } from 'react-router-dom';
import { useState } from "react";
// import { getBillById } from '../../services/billsService'
import { FeeLine } from '../../components/billComponents/FeeLine'
import AddFeeLineModalWindow from '../../components/billComponents/AddFeeLineModalWindow'
import { getCollaboratorById } from "../../services/collaboratorData"
import { updateBillApi } from '../../services/billsService'
import { connect } from 'react-redux';
import { deleteSpent, getBillById } from '../../redux/actions/billsActions'
import { get } from "react-hook-form";


class BillByIdComponent extends PureComponent {
    constructor(props) {
        super(props)
        this.state = {
            bill: {},
            isShowingForm: false
        }
    }
    componentDidMount() {
        console.log("dans le mount")
        // // console.log(this.props.bill)
        // // console.log(this.props.getBill(this.props.billId))
        this.setState({
            bill: this.props.bill
        })
        this.props.getBill(this.props.billId)
    }
    componentDidUpdate() {
        console.log("dans le up")
        // console.log(this.props.bill)
        // console.log(this.props.getBill(this.props.billId))
            // this.setState({
            //     bill: this.props.bill
            // })
            // this.setState({
            //     bill: this.props.bill
            // })
            this.setState({
                bill: this.props.bill
            })
    }

    handleAddFeeLineClick = () => {
        this.setState({
            isShowingForm: true
        })
    }
    handleCloseFeeLineForm = () => {
        this.setState({
            isShowingForm: false
        })
    }
    handleSaveFeeLine = (feeLine) => {
        console.log("formDATA de bill by id")
        console.log(feeLine)
        updateBillApi(feeLine)
    }
    handleDelete = (i) => {
        console.log("handledelete"+i)
        this.props.deleteSpent(i,this.props.bill.id)

    }

    render() {
        return (
            <div>
                {this.state.isShowingForm ?
                    <AddFeeLineModalWindow
                        closeForm={this.handleCloseFeeLineForm}
                        bill={this.state.bill}
                        collaborator={this.state.collaborator}
                        handleSave={this.handleSaveFeeLine}
                    /> : null}
                <h4>Collaborateur id : {this.props.bill.collaboratorId !== null ? this.props.bill.collaboratorId : null}</h4>
                <h4>Bill id : {this.props.bill.id !== null ? this.props.bill.id : null}</h4>
                <button onClick={() => this.handleAddFeeLineClick()} className="h-10 px-5 m-2 text-gray-100 transition-colors duration-150 bg-gray-700 rounded-lg focus:shadow-outline hover:bg-gray-800">Ajouter ligne de frais</button>

                <div className="flex flex-wrap justify-around">{this.props.bill.spents !== undefined ? this.props.bill.spents.map((spent, index) => <FeeLine key={index} FeeLine={spent} delete={this.handleDelete} />) : null}</div>
            </div>
        )
    }
}

export function GetId(props) {
    console.log("dans le get")
    const { id } = useParams()
    return (
        <BillByIdComponent
            billId={id}
            bill={props.bill}
            deleteSpent={props.deleteSpent}
            getBill={props.getBillById}
        />)
}


const mapStateToProps = (state) => {
    console.log("dans le map")
    console.log(state.bills.bill)
    return {
        bill: state.bills.bill,
        isLoading: state.bills.isLoading,
    }
}

const mapActionToProps = (dispatch) => {
    return {
        deleteSpent: (spentId,billId) => dispatch(deleteSpent(spentId,billId)),
        getBillById: (id) => dispatch(getBillById(id))
    }
}

export default connect(mapStateToProps, mapActionToProps)(GetId)