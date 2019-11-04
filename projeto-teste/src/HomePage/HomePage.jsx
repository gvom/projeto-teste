import React from 'react';
import { history, Role } from '@/_helpers';

import { userService, authenticationService } from '@/_services';
import { lembreteService } from '../_services/lembrete.service';

class HomePage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            currentUser: authenticationService.currentUserValue,
            userFromApi: null,
            lstLembrete: null
        };

    }

    componentDidMount() {
        const { currentUser } = this.state;
        userService.getById(currentUser.id).then(userFromApi => this.setState({ userFromApi }));

        lembreteService.getAll().then(lstLembrete => this.setState({ lstLembrete }));
    }

    cadastro() {
        history.push('/cadastrar');
    }

    render() {
        const { currentUser, userFromApi, lstLembrete } = this.state;
        return (
            <div>
                
                <p>Seu perfil de usuario é : <strong>{currentUser.role}</strong>.</p>
                <p>Seu perfil permite :
                    {currentUser.role == "Admin" && <strong> Leitura / Edição / Adição / Remoção </strong>}
                    {currentUser.role != "Admin" && <strong> Leitura </strong>}
                    de lembretes.
                </p>

                
                <div className="form-group md-1">
                    <button className="btn btn-primary" onClick={this.cadastro} ><b><i class="material-icons" style={{ color: 'white' }}>note_add</i>Novo</b></button>
                </div>
                <table className="table table-striped table-bordered">
                    <thead>
                        <tr>
                            {currentUser.role == "Admin" &&
                                <th scope="col-md-1">Ação</th>
                            }
                            <th scope="col">Nome</th>
                            <th scope="col">Descrição</th>
                            <th scope="col">Data</th>
                            <th scope="col">Hora</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            {currentUser.role == "Admin" &&
                                <td>
                                    <center>
                                        <a>
                                            <i class="material-icons" style={{ color: 'blue' }}>edit</i>
                                        </a>
                                        <a>
                                            <i class="material-icons" style={{ color: 'red' }}>delete</i>
                                        </a>
                                    </center>
                                </td>
                            }
                            <td>2</td>
                            <td>3</td>
                            <td>4</td>
                            <td>5</td>
                        </tr>
                        <tr>
                            {currentUser.role == "Admin" &&
                                <td>
                                    <center>
                                        <a>
                                            <i class="material-icons" style={{ color: 'blue' }}>edit</i>
                                        </a>
                                        <a>
                                            <i class="material-icons" style={{ color: 'red' }}>delete</i>
                                        </a>
                                    </center>
                                </td>
                            }
                            <td>2</td>
                            <td>3</td>
                            <td>4</td>
                            <td>5</td>
                        </tr>
                        
                        

                    </tbody>
                </table>
            </div>
        );
    }
}

export { HomePage };