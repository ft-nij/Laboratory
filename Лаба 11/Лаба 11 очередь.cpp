#include <iostream>
#include <fstream>
using namespace std;
struct Node {
    int key;
    Node* next;
};
struct Queue {
    Node* head;
    Node* tail;
};
// Создание очереди
Queue* createQueue() {
    Queue* q = new Queue;
    q->head = nullptr;
    q->tail = nullptr;
    return q;
}
// Добавление элемента в очередь
void enqueue(Queue* q, int key) {
    Node* newNode = new Node;
    newNode->key = key;
    newNode->next = nullptr;
    if (q->tail == nullptr) {
        q->head = newNode;
        q->tail = newNode;
    }
    else {
        q->tail->next = newNode;
        q->tail = newNode;
    }
}
// Удаление элемента из очереди
void dequeue(Queue* q) {
    if (q->head == nullptr) {
        cout << "Queue is empty" << endl;
        return;
    }
    Node* temp = q->head;
    q->head = q->head->next;
    delete temp;
    if (q->head == nullptr) {
        q->tail = nullptr;
    }
}
// Печать очереди
void printQueue(Queue* q) {
    Node* currentNode = q->head;
    while (currentNode != nullptr) {
        cout << currentNode->key << " ";
        currentNode = currentNode->next;
    }
    cout << endl;
}
// Запись очереди в файл
void saveQueueToFile(Queue* q, string filename) {
    ofstream file;
    file.open(filename);
    Node* currentNode = q->head;
    while (currentNode != nullptr) {
        file << currentNode->key << endl;
        currentNode = currentNode->next;
    }
    file.close();
}
// Восстановление очереди из файла
Queue* loadQueueFromFile(string filename) {
    Queue* q = createQueue();
    ifstream file;
    file.open(filename);
    int key;
    while (file >> key) {
        enqueue(q, key);
    }
    file.close();
    return q;
}
// Уничтожение очереди
void destroyQueue(Queue* q) {
    while (q->head != nullptr) {
        dequeue(q);
    }
    delete q;
}
int main() {
    Queue* q = createQueue();
    setlocale(0, "rus");
    int k;
    int val;
    cout << "Введите количество элементов: ";
    cin >> k;
    for (int i = 1; i <= k; i++) {
        cout << i << ". ";
        cin >> val;
        enqueue(q, val);
    }
    cout << "Очередь: ";
    printQueue(q);
    dequeue(q);
    cout << "Очередь после удаления: ";
    printQueue(q);
    cout << "Очередь после добавления элемента: ";
    enqueue(q, 4);
    printQueue(q);
    cout << "Очередь успешно записана в файл!" << endl;
    cout << "Очередь успешно удалена!" << endl;
    saveQueueToFile(q, "queue.txt");
    destroyQueue(q);
    Queue* loadedQueue = loadQueueFromFile("queue.txt");
    cout << "Очередь после восстановления из файла: ";
    printQueue(loadedQueue);
    destroyQueue(loadedQueue);
    return 0;
}