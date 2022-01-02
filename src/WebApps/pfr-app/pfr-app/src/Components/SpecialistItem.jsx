import React from 'react';

const SpecialistItem = (props) => {
    return (
            <div className="flex m-2 bg-white shadow-lg rounded-xl flex-none">
                <div className="certificate__content">

                    <div className="p-2">
                        <img width="auto" height="300" src={props.specialist.avatar} className=" rounded-xl"></img>

                    </div>
                    <div className="px-4"><strong>{props.specialist.fio}</strong></div>
                    <div className="px-4 py-2 pb-6">{props.specialist.specialnost}</div>

                    {/*<div className="post__btn">*/}
                    {/*    <button>Удалить</button>*/}
                    {/*</div>*/}

                    {/*<strong>{props.specialist.id}</strong>*/}
                </div>
            {/*<div className="flex m-2 bg-white border-2">*/}
            {/*    <div className="certificate__content">*/}
            
            {/*        <div>*/}
            {/*            <img width="auto" height="200" src="https://images.unsplash.com/photo-1522228115018-d838bcce5c3a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=300&q=60"></img>*/}
            {/*            Практикующий психолог*/}
            {/*        </div>*/}
            {/*        <strong>May Lam</strong>*/}
            {/*        <div className="post__btn">*/}
            {/*            <button>Удалить</button>*/}
            {/*        </div>*/}
            {/*    </div>*/}
            {/*</div>*/}
            {/*<div className="flex m-2 bg-white border-2">*/}
            {/*    <div className="certificate__content">*/}
            
            {/*        <div>*/}
            {/*            <img width="auto" height="200" src="https://images.unsplash.com/photo-1522228115018-d838bcce5c3a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=300&q=60"></img>*/}
            {/*            Практикующий психолог*/}
            {/*        </div>*/}
            {/*        <strong>May Lam</strong>*/}
            {/*        <div className="post__btn">*/}
            {/*            <button>Удалить</button>*/}
            {/*        </div>*/}
            {/*    </div>*/}
            {/*</div>*/}
            {/*<div className="flex m-2 bg-white border-2">*/}
            {/*    <div className="certificate__content">*/}
            
            {/*        <div>*/}
            {/*            <img width="auto" height="200" src="https://images.unsplash.com/photo-1522228115018-d838bcce5c3a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=300&q=60"></img>*/}
            {/*            Практикующий психолог*/}
            {/*        </div>*/}
            {/*        <strong>May Lam</strong>*/}
            {/*        <div className="post__btn">*/}
            {/*            <button>Удалить</button>*/}
            {/*        </div>*/}
            {/*    </div>*/}
            {/*</div>*/}
        </div>
    );
};

export default SpecialistItem;