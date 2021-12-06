using System;

namespace RxPresentation {
    class Client : IObserver<string> {
        public void OnCompleted() => Console.WriteLine("Completed");
        public void OnError(Exception error) => Console.WriteLine("An error occured!");
        public void OnNext(string value) => showContent(value);
        void showContent(string content) => Console.WriteLine(content);
    }
}
