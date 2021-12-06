using System;
using System.Reactive.Linq;

namespace RxPresentation {
    class Program {

        private static Slave s1 = new Slave1();
        private static Slave s2 = new Slave2();

        private static IObservable<Mail> newsProvider = new NewsProvider();
        private static IObserver<string> client = new Client();

        private static void select() {
            newsProvider
                .Select(item => item.content)
                .Subscribe(client);
        }

        private static void where() {
            newsProvider
                .Where(item => !item.ad)
                .Select(item => item.content)
                .Subscribe(client);
        }

        private static void selectMany() {
            newsProvider
                .Where(item => !item.ad)
                .SelectMany(item =>
                    s1.summarize(item)
                )
                .Select(item => item.content)
                .Subscribe(client);
        }

        private static void zip() {
            newsProvider
                .Where(item => !item.ad)
                .SelectMany(item =>
                    Observable.Zip(
                        s1.summarize(item),
                        s2.summarize(item),
                        (result1, result2) => {
                            return result1.rating > result2.rating ? result1 : result2;
                        }
                    )
                )
                .Select(item => item.content)
                .Subscribe(client);
        }

        static void Main(string[] args) {
            //select();
            //where();
            //selectMany();
            zip();
        }
    }
}
