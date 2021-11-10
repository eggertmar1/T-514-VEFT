// TODO: Implement the order service
/*
ORDER SERVICE (40%) 
It should be implemented as a NodeJS application using RabbitMQ1.
It should consume the order created event using the queue “order_queue”2.
It should create a new order using information from the event3.
It should also create order items using information from the same event
*/

const amqp = require('amqplib/callback_api');
const {Order, OrderItem} = require('./data/db');

const messageBrokerInfo = {
    exchanges: {
        order: 'order_exchange'
    },
    queue: {
        orderQueue: 'order_queue'
    },
    routingKeys: {
        createOrder: 'create_order'
    }
}


const createMessageBrokerConnection = () => new Promise((resolve, reject) => {
    amqp.connect('amqp://localhost', (err,conn) => {
        if (err){reject(err); }
        resolve(conn);
    });
});

const createChannel = connection => new Promise((resolve, reject) => {
    connection.createChannel((err,channel) => {
        if (err){reject(err); }
        resolve(channel);
    });
});

const configureMessageBroker = channel => {
    const { order } = messageBrokerInfo.exchanges;
    const { orderQueue } = messageBrokerInfo.queue;
    const { createOrder } = messageBrokerInfo.routingKeys;
    channel.assertExchange(order, 'direct', { durable: true });
    channel.assertQueue(orderQueue, { durable: true });
    channel.bindQueue(orderQueue, order, createOrder);

};



const newOrder = async item => {
    const order = {};
    order.customerEmail = item.email;
    var tmp = item.items;
    order.totalPrice = 0;
    for(var i = 0; i < tmp.length; i++) {
        order.totalPrice += parseInt(tmp[i].unitPrice * tmp[i].quantity );
    }
    order.orderDate = new Date();
    try {
        const newOrder = await Order.create({
            customerEmail : item.email,
            totalPrice: order.totalPrice,
            orderDate: order.orderDate
        })
        newOrderItem(item, newOrder);
    }catch (error){
        throw(error);
    }
    

    

};
const newOrderItem = async(order, orderDetails) => {
    try {
        const item = {};
        var tmp = order.items;
        item.rowPrice = 0;
        for(var i = 0; i < tmp.length; i++) {
            item.rowPrice += await tmp[i].quantity * tmp[i].unitPrice;
        }
        for(var i = 0; i < tmp.length; i++) {
            const newOrder = await OrderItem.create({
                description : tmp[i].description,
                quantity: tmp[i].quantity,
                unitPrice: tmp[i].unitPrice,
                rowPrice: item.rowPrice,
                orderId: orderDetails._id
            })
        }
        return newOrder;
    } catch (error) {
        throw(error);
    }  
}

(async () => {
    const messageBrokerConnection = await createMessageBrokerConnection();
    const channel = await createChannel(messageBrokerConnection);

    configureMessageBroker(channel);


    const { orderQueue } = messageBrokerInfo.queue;
  

    channel.consume(orderQueue, data => {
        const data_json = JSON.parse(data.content.toString());
        const theOrder = newOrder(data_json);
    });
    
})().catch(e => console.error(e));