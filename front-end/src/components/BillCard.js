import { PureComponent } from "react"
import { Link } from 'react-router-dom'

export class BillCard extends PureComponent {
    constructor(props) {
        super(props)
        console.log(this.props.bill.spents.length)
        this.state = {
        }

    }
    componentDidMount() {
        var temp = 0
        this.props.bill.spents.forEach(spent => {
            temp += spent.amount
        })
        this.setState({
            total: temp
        })
    }

    render() {
        return (
            <div class="max-w-xs overflow-hidden rounded-lg shadow-lg ">
                <div class="px-6 py-4">
                    <h5 class="mb-3 text-xl font-semibold tracking-tight text-gray-800">Bill id : {this.props.bill.id}</h5>
                    <hr />
                    <p class="leading-normal text-gray-700">{this.props.bill.spents.length} {this.props.bill.spents.length > 1 ? " lignes" : " ligne"} de frais.</p>
                    {console.log("amount " + this.props.bill.id + " : ")}
                    {console.log(this.state.total)}
                    <p class="leading-normal text-gray-700">Total : {this.state.total}€</p>
                    <Link to={`/bills/${this.props.bill.id}`}><button class="h-10 px-5 m-2 text-gray-100 transition-colors duration-150 bg-gray-700 rounded-lg focus:shadow-outline hover:bg-gray-800">Gérer</button></Link>
                </div>
            </div>
        )
    }
}