using System;
using System.Reactive.Disposables;
using System.Reactive;
using System.Threading;

namespace RxPresentation {
    public class Summary {
        public Summary(string content, int rating) {
            this.content = content;
            this.rating = rating;
        }

        public string content;
        public int rating;
    }

    interface Slave {
        IObservable<Summary> summarize(Mail aussendung);
    }

    class Slave1 : Slave {
        public IObservable<Summary> summarize(Mail mail) => new AnonymousObservable<Summary>((emitter) => {

            Thread.Sleep(1000);
            emitter.OnNext(new Summary("Summary", 3));

            return Disposable.Empty;
        });
}

    class Slave2 : Slave {
        public IObservable<Summary> summarize(Mail aussendung) => new AnonymousObservable<Summary>((emitter) => {

            Thread.Sleep(2000);
            emitter.OnNext(new Summary("Better Summary", 9));

            return Disposable.Empty;
        });
    }
}
