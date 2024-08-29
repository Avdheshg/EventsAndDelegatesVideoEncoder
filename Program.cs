

namespace EventsAndDelegatesVideoEncoder
{

    // 1. Delegate
    public delegate void VideoEncodedEventHandler(object source, EventArgs eventArgs);

    public class Program
    {
        public static void Main(string[] args)
        {
            VideoEncoder videoEncoder = new VideoEncoder();
            
            MailService mailService = new MailService();
            MessageService messageService = new MessageService();

            videoEncoder.VideoEncodedEvent += mailService.OnVideoEncoded;
            videoEncoder.VideoEncodedEvent += messageService.OnVideoEncoded;

            videoEncoder.Encode();

        }
    }

    // Publisher
    public class VideoEncoder
    {
        // 2. Event
        public event VideoEncodedEventHandler VideoEncodedEvent;

        public void Encode()
        {
            Console.WriteLine("Video encoding in progress ...");

            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        public void OnVideoEncoded()
        {
            if (VideoEncodedEvent != null)
            {
                VideoEncodedEvent(this, EventArgs.Empty);
            }
        }

    }

    // Subscriber
    public class MailService
    {
        public void OnVideoEncoded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Video Encoded. Sending the mail...");
        }
    }

    public class MessageService
    {
        public void OnVideoEncoded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Video Encoded. Sending the message...");
        }
    }

}































