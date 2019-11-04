import React from 'react';
import { history, Role } from '@/_helpers';

import { lembreteService, authenticationService } from '@/_services';

class Cadastro extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            id: authenticationService,
            nome: null,
            descricao: null,
            data: null,
            hora: null 
        };
    }

    componentDidMount() {
        //lembreteService.getById(this.state.id).then(lembrete => this.setState({ lembrete }));
    }

    salvar(){
        history.push('/');
    }

    render() {
        const { lembrete } = this.state;
        return (
            <div>
                <h2>Cadastro de Lembrete</h2>
                <br></br>
                <form onSubmit={this.salvar}>
                    <input type="hidden" value={this.state.id} />
                    
                    <label>
                    <b>Nome:</b>  <br></br>
                    <input type="text" value={this.state.nome} />
                    </label><br></br>

                    <label>
                    <b>Descrição:</b>  <br></br>
                    <input type="text" value={this.state.descricao} />
                    </label><br></br>

                    <label>
                    <b>Data:</b>  <br></br>
                    <input type="text" value={this.state.data} />
                    </label><br></br>

                    <label>
                    <b>Horario:</b>  <br></br>
                    <input type="text" value={this.state.hora} />
                    </label><br></br>

                    <div className="form-group md-1">
                        <button type="submit" className="btn btn-primary">Salvar</button>
                    </div>
                </form>

                
            </div>
        );
    }
}

export { Cadastro };