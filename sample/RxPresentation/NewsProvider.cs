using System;
using System.Reactive.Disposables;
using System.Threading;

namespace RxPresentation {

    class Mail {
        public Mail(string content, bool ad=false) {
            this.content = content;
            this.ad = ad;
        }

        public string content;
        public bool ad = false;
    }
    class NewsProvider : IObservable<Mail> {
        public IDisposable Subscribe(IObserver<Mail> observer) {

            observer.OnNext(new Mail("Ad", true));
            Thread.Sleep(2000);
            observer.OnNext(new Mail("Good News :D"));

            return Disposable.Empty;
        }
    }
}
